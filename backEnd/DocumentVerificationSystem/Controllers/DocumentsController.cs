using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient; // Dapper
using DocumentVerificationSystem.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;  

namespace DocumentVerificationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public DocumentsController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

     
       [HttpPost("upload")]
public async Task<IActionResult> UploadDocument([FromForm] IFormFile file, [FromForm] string title, [FromForm] int userId)
        {
           
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Generate a unique verification code
            string verificationCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            Console.WriteLine("Request received");
            // Save file in the "UploadedFiles" directory
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Create the document object
            var document = new Document
            {
                Title = title,
                FilePath = filePath,
                VerificationCode = verificationCode,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            // Save the document to the database using EF Core
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return Ok(new { DocumentId = document.Id, VerificationCode = document.VerificationCode });
        }
        // GET: /api/documents
[HttpGet]
public async Task<IActionResult> GetDocuments()
{
    try
    {
        // Log to see if the data is being fetched
        Console.WriteLine("Fetching documents from the database...");

        var documents = await _context.Documents.ToListAsync();

        // Log to see the number of documents fetched
        Console.WriteLine($"Documents fetched: {documents.Count}");

        if (documents == null || !documents.Any())
        {
            return NotFound("No documents found.");
        }

        return Ok(documents);
    }
    catch (Exception ex)
    {
        // Catch any exceptions and log them
        Console.WriteLine($"Error occurred: {ex.Message}");
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}



        // GET: /api/documents/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return NotFound("Document not found.");

            return Ok(new
            {
                document.Id,
                document.Title,
                document.FilePath,
                document.VerificationCode,
                document.Status,
                document.CreatedAt,
                document.UserId
            });
        }

        // POST: /api/verify
       [HttpPost("verify")]
        public async Task<IActionResult> VerifyDocument([FromBody] VerifyRequest request)
        {
            Console.WriteLine("Received request for verification");

         if (string.IsNullOrEmpty(request.VerificationCode))
        return BadRequest("Verification code is required.");

    // Using Dapper to query the document by verification code
    using (var dbConnection = new SqlConnection(_connectionString))
    {

        await dbConnection.OpenAsync();

        // Query to find document by verification code
        var query = "SELECT Id, Status FROM Documents WHERE VerificationCode = @VerificationCode";
        var document = await dbConnection.QueryFirstOrDefaultAsync<Document>(query, new { request.VerificationCode });

        if (document == null)
            return NotFound("Document not found with the provided verification code.");

        // Update the document status to 'Verified' using Dapper
        var updateQuery = "UPDATE Documents SET Status = 'Verified' WHERE Id = @DocumentId";
        await dbConnection.ExecuteAsync(updateQuery, new { DocumentId = document.Id });
        Console.WriteLine($"Document {document.Id} successfully verified");
        return Ok(new { Message = "Document verified successfully.", DocumentId = document.Id });
    }
        }

        // POST: /api/verify-ef (EF Core-based query for verifying document)
[HttpPost("verify-ef")]
public async Task<IActionResult> VerifyDocumentEF([FromBody] VerifyRequest request)
{
    if (string.IsNullOrEmpty(request.VerificationCode))
        return BadRequest("Verification code is required.");


    // Start the stopwatch to measure performance
    Console.WriteLine("Received EF verification request");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    // Using EF Core to query the document by verification code
    var document = await _context.Documents
        .FirstOrDefaultAsync(d => d.VerificationCode == request.VerificationCode);

    if (document == null)
    {
        stopwatch.Stop();
        return NotFound("Document not found with the provided verification code.");
    }

    // Update the document status to 'Verified' using EF Core
    document.Status = "Verified";
    _context.Documents.Update(document);
    await _context.SaveChangesAsync();

    stopwatch.Stop();

    // Log the execution time for analysis
    var executionTime = stopwatch.ElapsedMilliseconds;

    // Return performance logs along with the result
    return Ok(new
    {
        Message = "Document verified successfully.",
        DocumentId = document.Id,
        ExecutionTimeInMilliseconds = executionTime
    });
}
    
    }

    // Request class for the verify endpoint
    public class VerifyRequest
    {
        public string VerificationCode { get; set; }
    }
}

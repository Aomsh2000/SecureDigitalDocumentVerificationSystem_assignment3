# SecureDigitalDocumentVerificationSystem_assignment3

Secure Digital Document Verification System - Frontend
This is the frontend application for the Secure Digital Document Verification System. It is built using Angular and utilizes NgRx for state management and RxJS for handling asynchronous operations.

Features
Displays a list of documents fetched from an API.
Allows the user to interact with the state of the documents using NgRx (Redux-style state management).
Uses effects to manage asynchronous operations like loading and handling errors.
Implements store devtools for debugging.
Prerequisites
Before running the project, ensure you have the following installed:

Node.js (LTS version recommended)
npm (Node Package Manager)
You can check if Node.js and npm are installed by running the following commands:

bash

node -v
npm -v
If they are not installed, you can download and install Node.js from here.

Setup Instructions
Follow these steps to set up the project on your local machine:

1. Clone the Repository
Clone the repository to your local machine using Git:

bash

git clone https://github.com/Aomsh2000/SecureDigitalDocumentVerificationSystem_assignment3.git
2. Navigate to the Project Folder
bash

cd secure-digital-document-verification
3. Install Dependencies
Install the project dependencies by running the following command:

bash

npm install
This will install all the required dependencies listed in the package.json file, including Angular, NgRx, and other packages.

4. Configure the Backend API (Optional)
If you're working with a backend API, make sure it's running on your local environment or a remote server. The frontend assumes the API is available at a certain endpoint.

You can configure the API URL in the document.service.ts file (or wherever the API call is made) to match your backend setup.

5. Run the Development Server
To run the project locally in development mode, use the following command:

bash

npm start
This will start the development server. Open your browser and navigate to http://localhost:4200 to view the application.

6. Run Tests (Optional)
To ensure everything is working correctly, you can run unit tests using the following command:

bash

npm run test
This will run the tests and provide a report in the terminal.

7. Build the Project (Optional)
If you want to build the project for production, run the following command:

bash
npm run build
This will generate the production-ready files in the dist/ directory.

Project Structure
src/app/: Contains the main application code.

app.component.ts: Main component.
app.module.ts: Main module (not used in standalone setup).
dashboard/: Component that displays documents.
store/: Contains NgRx actions, reducers, and effects for managing the application state.
services/: Contains services to interact with APIs.
src/environments/: Contains environment-specific configurations (e.g., for production and development).

angular.json: Angular configuration file.

Technologies Used
Angular: Framework for building the frontend.
NgRx: State management library based on Redux.
RxJS: Reactive programming library used for handling asynchronous operations.
TypeScript: Superset of JavaScript used to build the application.
NgRx Store, Effects, and StoreDevtools: State management, side effects handling, and store debugging tools.
Contributing
We welcome contributions to this project! To contribute:

Fork the repository.
Create a new branch for your feature or fix.
Make your changes and test them.
Submit a pull request with a description of the changes.
License
This project is licensed under the MIT License - see the LICENSE file for details.
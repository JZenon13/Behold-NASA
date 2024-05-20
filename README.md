# Behold NASA

Behold NASA is a project that fetches photos captured by Mars rovers on specific dates using the NASA API and stores them locally. The project consists of a backend written in C#/.NET Core and a frontend built with React using Vite.

## Project Structure

The project is divided into two main parts:

1. **Backend**: The backend is a RESTful API built with C#/.NET Core. It is responsible for fetching data from the NASA API and providing endpoints that the frontend can consume.

2. **Frontend**: The frontend is a single-page application built with React and Vite. It communicates with the backend to fetch data and presents it to the user in a user-friendly format.

## Getting Started

To get started with the project, you need to have Docker installed on your machine.

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run `docker-compose up` to start the application.

## Usage

Once the application is running:

1. Open your web browser.
2. Navigate to the frontend server's URL [http://localhost:5173/](http://localhost:5173/).

You should now be able to see the Mars rover photos fetched from the NASA API.

# 🎨 Chicago Art Explorer - Assignment

## Overview

The **Chicago Art Explorer** is a web application built with **ASP.NET Core MVC**. The project interacts with the **Chicago Institute of Art's public API** to present a list of artworks and allows users to view details about each artwork, including the artist, medium, and date. The application also provides a full-size image of the artwork.

This project demonstrates **API integration**, **MVC architecture**, **front-end and back-end communication**, and **user interface (UI) design**. 

---

## Features

- **Artwork Listing**: Displays a list of up to 30 artworks from the Chicago Institute of Art.
- **Search Functionality**: Allows users to search for artworks by title.
- **Artwork Details**: Displays detailed information about a selected artwork, including:
  - Title
  - Artist
  - Medium
  - Date of creation
  - Place of origin
- **Full-Size Image**: If available, users can view a high-resolution image of the artwork.
- **Back and Search Buttons**: Navigation to go back to the search page or perform a new search.

---

## Technologies Used

- **C#** - Programming language
- **ASP.NET Core MVC** - Framework for building the web application
- **HTML/CSS** - For the structure and styling of the pages
- **RESTful APIs** - To retrieve artwork data from the Chicago Institute of Art's API
- **Visual Studio** - IDE for development

---

## API Details

The application interacts with the Chicago Institute of Art's public API. The endpoint used returns a list of artworks, which includes metadata like title, artist, medium, date, and image details.

- **Artwork List API URL**:  
  `https://api.artic.edu/api/v1/artworks?fields=id,title,artist_title,image_id,date_display,thumbnail,medium_display&page=1&limit=30`
  
- **Image URL** (for displaying artwork images):  
  `https://www.artic.edu/iiif/2/{image_id}/full/843,/0/default.jpg`

- **Search API URL** (for querying artworks by name):  
  `https://api.artic.edu/api/v1/artworks/search?q={search_term}&fields=id,title,artist_title,image_id,date_display,thumbnail,medium_display&page=1&limit=30`

---

## Setup Instructions

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/imkappy/chicago-art-explorer.git
   Open the project in Visual Studio.
2. Open the project in Visual Studio.
3. Build and run the application.
4. Navigate to the home page to start searching for artworks.

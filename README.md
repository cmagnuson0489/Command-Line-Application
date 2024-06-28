# Command-Line-Application
  - This repository will be for a command line application that will be written primarily in C#.
  - This application needs to consist of the following. 
  -  Ability to take in two inputs and a flag.
  - A directory that contains the files that are to be analyzed.
  - A path for the output file (including file name and extension).
  - A flag to determine whether or not to include subdirectories contained (and all subsequently embedded subdirectories) within the input directory ([a.] above).
  - Processes each of the files in the directory (and subdirectories if the flag is present).
  - Determines using a file signature if a given file is a PDF or a JPG.
  - JPG files start with 0xFFD8.
  - PDF files start with 0x25504446.
  - For each file that is a PDF or a JPG, creates an entry in the output CSV containing the following information
  - The full path to the file.
  - The actual file type (PDF or JPG).
  - The MD5 hash of the file contents.


# Feature Development

   # Simplify Deployment and Access
     - Web API: Convert your command line application into a web API. This allows users to interact with your application through HTTP requests without needing to run the code locally.
     - Technologies like ASP.NET Core can help you create a robust API. I will then deploy the API to a cloud platform like Azure, AWS, or Heroku so it can be accessed via the internet.
     - Containerization: Use Docker to containerize your application. This will wrap the application and all its dependencies into a container that can be easily run on any system that has Docker installed.  
     - Executable Releases: Build and release executable versions of your application for different operating systems (Windows, MacOS, Linux) on your GitHub releases page. This allows users to download and run your program without compiling the source code. 
  # Enhance Usability and features
    - Interactive CLI: Enhance the command line interface to be more interactive. Use libraries like Spectre.Console or CommandLineParser to improve how inputs are parsed.
    - GUI Option: Add a basic graphical user interface (GUI) as an alternative to the command line interface. maybe something simple using Windows Forms or WPF, making it easier for non-technical users to interact with.
    - Extended File Type Support: Expand the types of files the application can recognize beyond just PDF and JPG.
    - Performance Optimization: Implement multithreading or asynchronous processing to handle large directories more efficiently, especially when processing subdirectories.

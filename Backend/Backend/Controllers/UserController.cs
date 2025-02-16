using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Backend.Infrastructure;
using Backend.Models.ModelsFull;
using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase 
    {
       
        [HttpPost("login/username")]
        public IActionResult UsernameLogin(string username, string password)
        {

            UserModelID userModelID = UsersService.SignIn(null, username, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(new { Token = Backend.Program.Globals.tokenProvider.Create(userModelID.Email, userModelID.Password, userModelID.Role) });
        }

        [HttpPost("login/email")]
        public IActionResult EmailLogin(string email, string password)
        {
            UserModelID userModelID = UsersService.SignIn(email, null, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(new { Token = Backend.Program.Globals.tokenProvider.Create(userModelID.Email, userModelID.Password, userModelID.Role) });
        }

        

        [HttpPost("register/first")]
        public IActionResult RegisterFirst(string username, string email, string password)
        {

            if (UsersService.Exists("email", email, Backend.Program.Globals.db.Connection))
            {
                return Conflict();
            }

            return Ok();
        }

        [HttpPost("register/second")]
        public IActionResult RegisterSecond([FromBody] UserModelID userModelID)
        {
            if (userModelID == null)
            {
                return BadRequest("Invalid data.");
            }

            userModelID = UsersService.SignUp(userModelID, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return BadRequest("Couldn't insert to DB. Check if request is valid.");
            }

            return Ok();
        }

        [HttpPost("initToken")]
        public IActionResult InitToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return null;

            var email = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var role = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

            // Assuming you have a method to get the user by email
            var user = UsersService.SelectByEmail(email, Backend.Program.Globals.db.Connection);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
           
        }


        [HttpPost("edit/userinfo")]
        public IActionResult EditUserInfo([FromBody] UserModelID ChangedUserModelID)
        {
            if (ChangedUserModelID == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!UsersService.ChangeInfo(ChangedUserModelID, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update info in DB. Check if user exist or request is valid.");
            }

            return Ok();
        }

        [HttpPost("edit/userpassword")]
        public IActionResult EditUserPassword(uint userID, string password)
        {
            if (userID == null)
            {
                return BadRequest("Invalid data");
            }

            if (!UsersService.ChangePassword(userID, password, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update password in DB. Check if user exist or request is valid.");
            }

            return Ok();
        }

        [HttpPost("edit/userphoto")]
        public IActionResult EditUserPhoto(uint userID, IFormFile photo)
        {
            if (userID == 0 || photo == null)
            {
                return BadRequest("Invalid data.");
            }

            // Upload the photo to the FTP server
            string ftpUrl = "ftp://ftp.byethost7.com/htdocs/users/";
            string ftpUsername = "b7_37868429";
            string ftpPassword = "hello12_";
            string fileName = $"{userID}{Path.GetExtension(photo.FileName)}";
            string fileUrl = ftpUrl + fileName;

            try
            {
                // Check if the file already exists and delete it
                FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                deleteRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                try
                {
                    using (var deleteResponse = (FtpWebResponse)deleteRequest.GetResponse())
                    {
                        // File deleted successfully
                    }
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return StatusCode(500, $"An error occurred while deleting the existing photo: {ex.Message}");
                    }
                }

                // Upload the new file
                using (var stream = photo.OpenReadStream())
                {
                    FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    uploadRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    uploadRequest.ContentLength = stream.Length;

                    using (var requestStream = uploadRequest.GetRequestStream())
                    {
                        stream.CopyTo(requestStream);
                    }

                    using (var response = (FtpWebResponse)uploadRequest.GetResponse())
                    {
                        if (response.StatusCode != FtpStatusCode.ClosingData)
                        {
                            return StatusCode(500, "Failed to upload photo to FTP server.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while uploading the photo: {ex.Message}");
            }

            // Update the user's photo URL in the database
            string photoUrl = $"http://gossip.byethost7.com/users/{fileName}";
            if (!UsersService.ChangePhoto(userID, photoUrl, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update photo in DB. Check if user exists or request is valid.");
            }

            return Ok(new { PhotoUrl = photoUrl });
        }

    }
}

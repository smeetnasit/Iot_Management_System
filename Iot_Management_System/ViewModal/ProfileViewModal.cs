//using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Iot_Management_System.Hepler;
//using Iot_Management_System.Models;

//namespace Iot_Management_System.ViewModal
//{
//    public class ProfileViewModal
//    {
//        private readonly HttpClient client;
//        private readonly IClientHelper _clientHelper;
//        private readonly IDataProtector _protector;

//        public ProfileViewModal(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
//        {
//            _clientHelper = clientHelper;
//            _protector = dataProtectionProvider.CreateProtector("MyCookieEncryptionPurpose");
//        }

//        public async Task<GetProfile> GetEmpProfile(string email)
//        {
//            GetProfile result = new GetProfile();

//            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
//            string url = $"https://localhost:7238/api/Profile/Get_Emp_Profile?email={email}";

//            var response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<GetProfile>(content);
//            }
//            return result;
//        }


//        public async Task<CommonResponseModel> UpsertProfile(Profile profile)
//        {

//            var userSignUpDTO = new ProfileDTO
//            {
//                Id = profile.Id,
//                EmpCode = profile.EmpCode,
//                EmpName = profile.EmpName,
//                Address1 = profile.Address1,
//                Address2 = profile.Address2,
//                Password = profile.Password,
//                Country = profile.Country,
//                State = profile.State,
//                City = profile.City,
//                CountryId = profile.CountryId,
//                StateId = profile.StateId,
//                CityId = profile.CityId,
//                MobileNo = profile.MobileNo,
//                PhoneNo = profile.PhoneNo,
//                Email = profile.Email,
//                EmpDesignation = profile.EmpDesignation,
//                Likes = profile.Likes,
//                Comments = profile.Comments,
//                Shares = profile.Shares,
//                Description = profile.Description,
//                ProfileLink_String = profile.ProfileLink_String,
//            };

//            CommonResponseModel res = new CommonResponseModel();
//            HttpClientHandler handler = new HttpClientHandler();
//            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
//            HttpClient client = new HttpClient(handler);
//            var serializedItemToCreate = JsonConvert.SerializeObject(userSignUpDTO);
//            var response = await client.PutAsync("https://localhost:7238/api/Profile/Upsert_Profile",
//                            new StringContent(serializedItemToCreate,
//                                    System.Text.Encoding.Unicode,
//                                    "application/json"));


//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
//            }
//            else
//            {
//                var errorContent = await response.Content.ReadAsStringAsync();
//                throw new Exception($"API call failed with status code: {response.StatusCode}, content: {errorContent}");
//            }
//            return res;
//        }



//        public async Task<string> UploadFileAsync(IFormFile file, string uploadPath)
//        {
//            try
//            {
//                var tempFilePath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
//                if (!File.Exists(tempFilePath))
//                {
//                    // Save the IFormFile to the temporary file path
//                    using (var stream = new FileStream(tempFilePath, FileMode.Create))
//                    {
//                        await file.CopyToAsync(stream);
//                    }
//                }
//                HttpClientHandler handler = new HttpClientHandler();
//                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
//                var client = new HttpClient(handler);
//                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7238/api/FileUpload/upload?filepath=" + uploadPath);
//                request.Headers.Add("accept", "*/*");
//                var content = new MultipartFormDataContent();
//                content.Add(new StreamContent(File.OpenRead(tempFilePath)), "file", file.FileName);
//                request.Content = content;
//                var response = await client.SendAsync(request);
//                var responseContent = await response.Content.ReadAsStringAsync();
//                response.EnsureSuccessStatusCode();

//                return (responseContent);
//            }
//            catch (Exception ex)
//            {
//                // Log or handle the exception appropriately
//                Console.WriteLine($"Error uploading file: {ex.Message}");
//                return ("");
//            }
//        }



//        public async Task<CommonResponseModel> AddPost(AddPostModal add)
//        {

//            var postsModelDTO = new PostsModelDTO
//            {
//                Id = add.Id,
//                EmpId = add.EmpId,
//                Post_Link_String = add.Post_Link_String,
//                Likes = add.Likes,
//                Comments = add.Comments,
//                Shares = add.Shares,
//                IsDeleted = add.IsDeleted,
//                CreatedAt = add.CreatedAt,

//            };

//            CommonResponseModel res = new CommonResponseModel();
//            HttpClientHandler handler = new HttpClientHandler();
//            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

//            HttpClient client = new HttpClient(handler);
//            var serializedItemToCreate = JsonConvert.SerializeObject(postsModelDTO);    
//            var response = await client.PostAsync("https://localhost:7238/api/Profile/Post_Insert",
//                                    new StringContent(serializedItemToCreate,
//                                            System.Text.Encoding.Unicode,
//                                            "application/json"));

//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
//            }
//            else
//            {
//                var errorContent = await response.Content.ReadAsStringAsync();
//                throw new Exception($"API call failed with status code: {response.StatusCode}, content: {errorContent}");
//            }
//            return res;
//        }


//        public async Task<List<PostsModelDTO>> Get_Post(int empId)
//        {
//            List<PostsModelDTO> results = new List<PostsModelDTO>();

//            try
//            {
//                var requestUrl = $"https://localhost:7238/api/Profile/Get_Post?empId={empId}";

//                HttpClientHandler handler = new HttpClientHandler();
//                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

//                using (HttpClient client = new HttpClient(handler))
//                {
//                    var response = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        var content = await response.Content.ReadAsStringAsync();
//                        results = JsonConvert.DeserializeObject<List<PostsModelDTO>>(content);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//                throw;
//            }

//            return results;
//        }


//    }
//}

namespace Emp_API.DTO
{
    public class Profile
    {
        public long Id { get; set; }

        public string? EmpCode { get; set; }
        public long? Likes { get; set; }
        public long? Comments { get; set; }
        public long? Shares { get; set; }

        public string? Description { get; set; }
        public List<IFormFile>? ProfileLink { get; set; }

        public string? ProfileLink_String { get; set; }


        //public string? EmpName { get; set; }

        //public string? Address1 { get; set; }

        //public string? Address2 { get; set; }

        //public long? Country { get; set; }

        //public long? State { get; set; }

        //public long? City { get; set; }

        //public long? MobileNo { get; set; }

        //public long? PhoneNo { get; set; }

        //public string? Email { get; set; }
        //public long? IsDeleted { get; set; }
        //public string? EmpDesignation { get; set; }
        //public long? EmpSalary { get; set; }
        //public string? Password { get; set; }
    }

    public class GetEmpProfile
    {
        public long Id { get; set; }

        public string? EmpCode { get; set; }


        public string? EmpName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public long? CountryId { get; set; }

        public long? StateId { get; set; }

        public long? CityId { get; set; }

        public long? MobileNo { get; set; }

        public long? PhoneNo { get; set; }

        public string? Email { get; set; }
        public string? EmpDesignation { get; set; }
        public string? Password { get; set; }


        public long? Likes { get; set; }
        public long? Comments { get; set; }
        public long? Shares { get; set; }

        public string? Description { get; set; }
        public string? ProfileLink_String { get; set; }
    }


    public class UpsertEmpProfile
    {
        public long Id { get; set; }

        public string? EmpCode { get; set; }


        public string? EmpName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public long? CountryId { get; set; }

        public long? StateId { get; set; }

        public long? CityId { get; set; }

        public long? MobileNo { get; set; }

        public long? PhoneNo { get; set; }

        public string? Email { get; set; }
        public string? EmpDesignation { get; set; }
        public string? Password { get; set; }


        public long? Likes { get; set; }
        public long? Comments { get; set; }
        public long? Shares { get; set; }

        public string? Description { get; set; }
        public IFormFile? ProfileLink { get; set; }

        public string? ProfileLink_String { get; set; }
    }




    public class AddPost
    {
        public long? Id { get; set; }
        public long? EmpId { get; set; }
        public IFormFile? PostLink { get; set; }
        public string? Post_Link_String { get; set; }
        public long? Likes { get; set; }
        public long? Comments { get; set; }
        public long? Shares { get; set; }
        public long? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }

        public long? TotalComments { get; set; }
        public long? TotalLikes { get; set; }
        public long? TotalShares { get; set; }


    }

    public class PostsModelDTO
    {
        public long Id { get; set; }
        public long? EmpId { get; set; }
        public IFormFile? PostLink { get; set; }
        public string? Post_Link_String { get; set; }
        public long? Likes { get; set; }
        public long? Comments { get; set; }
        public long? Shares { get; set; }
        public long? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }

        public long? TotalComments { get; set; }
        public long? TotalLikes { get; set; }
        public long? TotalShares { get; set; }
        public IFormFile? ProfileLink { get; set; }

        public string? ProfileLink_String { get; set; }
        public string? EmpName { get; set; }


    }

}

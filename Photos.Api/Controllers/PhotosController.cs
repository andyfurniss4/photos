using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Photos.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class PhotosController : ControllerBase
{
    private readonly IAmazonS3 _s3;

    public PhotosController(IAmazonS3 s3)
    {
        _s3 = s3;
    }

    [HttpGet(Name = "GetPhotos")]
    public async Task<IActionResult> Get()
    {
        var request = new ListObjectsV2Request
        {
            BucketName = "furn-photos",
            MaxKeys = 20,
        };

        try
        {
            var listResponse = await _s3.ListObjectsV2Async(request);
            return Ok(listResponse.S3Objects.Select(o => o.Key));
        }
        catch (Exception ex)
        {

            throw ex;
        }        
    }
}

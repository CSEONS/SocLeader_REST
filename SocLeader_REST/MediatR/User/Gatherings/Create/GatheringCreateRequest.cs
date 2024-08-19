using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text.Json.Serialization;
using static SocLeader_REST.Domain.Entities.Gathering;

namespace SocLeader_REST.MediatR.Gatherings.Create
{
    public class GatheringCreateRequest : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        public GatheringType Type { get; set; }
        public long Lat {  get; set; }
        public long Lon { get; set; }
        public string[] Tags { get; set; }
        public IFormFile PreviewPhotos { get; set; }
        
        [JsonIgnore]
        public ClaimsPrincipal? User;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PopcornWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        static List<Server> ServerList = new List<Server>();
        [HttpGet]
        public ActionResult<IEnumerable<Server>> Get()
        {
            return ServerList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Server> Get(Guid id)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                return ServerList[idx];
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Server value)
        {
            ServerList.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Server value)
        {
            ServerList[id] = value;
        }

        // PUT api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id, [FromBody] Server value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
                ServerList.RemoveAt(idx);
        }


        [HttpPut]
        [Route("duration/{id:guid}")]
        public void Put(Guid id, [FromBody] float value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                ServerList[idx].CurrentPosition = value;
            }
        }

        [HttpPut]
        [Route("streamer/{id:guid}")]
        public void Put(Guid id, [FromBody] Streamer value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                ServerList[idx].streamers.Add(value);
            }
        }

        [HttpPut]
        [Route("streamerupdate/{id:guid}")]
        public void Post(Guid id, [FromBody] Streamer value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                ServerList[idx].streamers.Find(x => x.Username == value.Username).Playing = value.Playing;
            }
        }

        [HttpDelete]
        [Route("streamer/{id:guid}")]
        public void Delete(Guid id, [FromBody] Streamer value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                int streamerIdx = ServerList[idx].streamers.FindIndex(x => x.Username == value.Username);
                if (streamerIdx != -1)
                {
                    ServerList[idx].streamers.RemoveAt(streamerIdx);
                }
            }
        }

        [HttpPut]
        [Route("video/{id:guid}")]
        public void Put(Guid id, [FromBody] VideoFile value)
        {
            int idx = ServerList.FindIndex(x => x.Id == id);
            if (idx != -1)
            {
                ServerList[idx].video = value;
            }
        }
    }
}

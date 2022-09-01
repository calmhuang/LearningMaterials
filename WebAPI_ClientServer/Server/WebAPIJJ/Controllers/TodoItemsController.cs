using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using WebAPIJJ.Models;

namespace WebAPIJJ.Controllers
{
    [Route("api")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;


        public TodoItemsController(TodoContext context)
        {
            _context = context;

            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();
        }

        [HttpGet("Lot/GetMaxTrackOutQty")]
        public ActionResult<ResponseBody> GetMaxTrackOutQty(string lot)
        {
            if (_context.Datas == null)
            {
                return NotFound();
            }
            var LotList = _context.Datas.ToList();
            var todoItem = LotList.Find(a => a.Lot == lot);

            if (todoItem == null)
                return NotFound();

            var Lot = JsonConvert.DeserializeObject<LotItem>(todoItem.Value);
            // var item = _context.Datas.FindAsync(id);

            if (Lot == null)
            {
                return NotFound();
            }

            var ret = new ResponseBody() { Code = 1, Message = String.Empty, Data = Lot.Qty };

            return ret;
        }


        [HttpGet("Lot/GetRecipeBylot")]
        public ActionResult<ResponseBody> GetRecipeBylot(string lot)
        {
            if (_context.Datas == null)
            {
                return NotFound();
            }
            var LotList = _context.Datas.ToList();
            var todoItem = LotList.Find(a => a.Lot == lot);

            if (todoItem == null)
                return NotFound();

            var Lot = JsonConvert.DeserializeObject<LotItem>(todoItem.Value);
            // var item = _context.Datas.FindAsync(id);

            if (Lot == null)
            {
                return NotFound();
            }

            var ret = new ResponseBody() { Code = 1, Message = String.Empty, Data = Lot.RecipeName };

            return ret;
        }

        [HttpGet("Lot/{lotno}")]
        public ActionResult<ResponseBody> GetLot(string lotno)
        {
            if (_context.Datas == null)
            {
                return NotFound();
            }
            var LotList = _context.Datas.ToList();
            var todoItem = LotList.Find(a => a.Lot == lotno);

            if (todoItem == null)
                return NotFound();

            var Lot = JsonConvert.DeserializeObject<LotItem>(todoItem.Value);
            // var item = _context.Datas.FindAsync(id);

            if (Lot == null)
            {
                return NotFound();
            }

            var ret = new ResponseBody() { Code = 1, Message = String.Empty, Data = Lot };

            return ret;
        }
        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Lot")]
        public async Task<ActionResult<LotItem>> PostLot(dynamic lot)
        {
          if (_context.Datas == null)
          {
              return Problem("Entity set 'TodoContext.TodoItems'  is null.");
          }
           var  str = Convert.ToString(lot);
            LotItem _todoItem = JsonConvert.DeserializeObject<LotItem>(str) ??new LotItem();

            var data = new Data() { Value = str, Lot = _todoItem.Lot };

            _context.Datas.Add(data);
           await _context.SaveChangesAsync();

            //var db = new TodoContext();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(PostLot), new { id = _todoItem.Lot }, _todoItem);
        }


        [HttpPost("Lot/Trackin/{lot}")]
        public ActionResult<ResponseBody> PostTrackin(string lot)
        {
            if (_context.Datas == null)
            {
                return NotFound();
            }
            var LotList = _context.Datas.ToList();
            var todoItem = LotList.Find(a => a.Lot == lot);

            if (todoItem == null)
                return NotFound();

            var Lot = JsonConvert.DeserializeObject<LotItem>(todoItem.Value);
            // var item = _context.Datas.FindAsync(id);

            if (Lot == null)
            {
                return NotFound();
            }

            var ret = new ResponseBody() { Code = 1, Message = $"{lot} : Track In 成功.", Data = null };

            return ret;
        }

        [HttpPost("Equipment")]
        public ActionResult<ResponseBody> PostAlarm(dynamic lot)
        {

            var ret = new ResponseBody() { Code = 1, Message = $"{lot} : Alarm 成功.", Data = null };

            return ret;
        }

        //private bool TodoItemExists(string id)
        //{
        //    //return (_context.LotItems?.Any(e => e.Lot == id)).GetValueOrDefault();
        //}
    }
}

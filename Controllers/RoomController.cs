﻿using Hotel_Booking.Model;
using Hotel_Booking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoom _RoomRepository;

        public RoomController(IRoom RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }
        [HttpGet]
        public ActionResult<ICollection<Room>> GetAllHotels()
        {
            var hotels = _RoomRepository.GetAllRoom();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Room>> GetHotelById(int id)
        {
            var rooms = _RoomRepository.GetRoomById(id);
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult<ICollection<Room>> CreateHotel(Room Rooms)
        {
            _RoomRepository.AddRoom(Rooms);
            return Ok(Rooms);
        }

        [HttpPut("{id}")]
        public ActionResult<ICollection<Room>> UpdateHotel(int id, Room rooms)
        {
            _RoomRepository.UpdateRoom(rooms, id);
            return Ok(rooms);
        }

        [HttpDelete("{id}")]
        public ActionResult<ICollection<Room>> DeleteHotel(int id)
        {
            _RoomRepository.DeleteRoom(id);
            return Ok(id);
        }
    }
}

using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        public CouponsController(AppDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpGet]
        public ResponseDto<IEnumerable<CouponDto>> Get()
        {
            try
            {
                return ResponseDto<IEnumerable<CouponDto>>.CreateResponseDto(this._db.Coupons.ToList().Select(a=> this._mapper.Map<CouponDto>(a)));
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<CouponDto>>.CreateFailureResponseDto(ex);
            }
            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto<CouponDto> Get(int id)
        {
            try
            {
                return ResponseDto<CouponDto>.CreateResponseDto(this._mapper.Map<CouponDto>(_db.Coupons.FirstOrDefault(a => a.CouponId == id)));
            }
            catch (Exception ex)
            {
                return ResponseDto<CouponDto>.CreateFailureResponseDto(ex);
            }
            return null;
        }

        [HttpGet]
        [Route("getByCode/{code}")]
        public ResponseDto<CouponDto> GetByCode(string code)
        {
            try
            {
                return ResponseDto<CouponDto>.CreateResponseDto(this._mapper.Map<CouponDto>(_db.Coupons.FirstOrDefault(a => a.CouponCode.ToLower() == code.ToLower())));
            }
            catch (Exception ex)
            {
                return ResponseDto<CouponDto>.CreateFailureResponseDto(ex);
            }
            return null;
        }

        [HttpPost]
        public ResponseDto<CouponDto> Post([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon obj = this._mapper.Map<Coupon>(coupon);
                this._db.Coupons.Add(obj);
                this._db.SaveChanges();
                return ResponseDto<CouponDto>.CreateResponseDto(this._mapper.Map<CouponDto>(obj));

            }
            catch (Exception ex)
            {
                return ResponseDto<CouponDto>.CreateFailureResponseDto(ex);
            }
            return null;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto<CouponDto> Delete([FromRoute] int id)
        {
            try
            {
                Coupon obj = this._db.Coupons.First(a=>a.CouponId == id);
                this._db.Coupons.Remove(obj);
                this._db.SaveChanges();
                return ResponseDto<CouponDto>.CreateResponseDto(this._mapper.Map<CouponDto>(obj));

            }
            catch (Exception ex)
            {
                return ResponseDto<CouponDto>.CreateFailureResponseDto(ex);
            }
            return null;
        }
    }
}

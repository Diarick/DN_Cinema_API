using Model.Models;
using Model.ViewModel;
using ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class MoviesService
    {
        DBCtx _ctx;
        MoviesRepository _repo;

        public MoviesService()
        {
            _ctx = new DBCtx();
            _repo = new MoviesRepository(_ctx);
        }

        public List<Movies> GetList()
        {
            try { 
                List<Movies> Datas = _repo.GetList().ToList();
                return Datas;
            }
            catch(Exception x)
            {
                List<Movies> datas = new List<Movies>();
                Movies data = new Movies() { id = 0, title = "Error", description = x.Message, created_at = DateTime.Now, updated_at = DateTime.Now };
                datas.Add(data);
                return datas;
            }
            finally
            {
                _ctx.Dispose();
            }
        }
        public Movies GetSingle(int id)
        {
            try
            {
                Movies Data = _repo.GetList().Where(f => f.id == id).FirstOrDefault();

                if (Data == null)
                    return new Movies() { id = 0, title = "Oops", description = "Data tidak ditemukan", created_at = DateTime.Now, updated_at = DateTime.Now };

                return Data;
            }
            catch (Exception x)
            {
                Movies data = new Movies() { id = 0, title = "Error", description = x.Message, created_at = DateTime.Now, updated_at = DateTime.Now };
                return data;
            }
            finally
            {
                _ctx.Dispose();
            }
        }
        public ApiResponseViewModel Add(Movies data)
        {
            try
            {
                _repo.Insert(data);

                return new ApiResponseViewModel() { status = true, statusCode = 200, message = "Movie has been created"};
            }
            catch (Exception x)
            {
                return new ApiResponseViewModel() { status = false, statusCode = 400, message = x.Message };
            }
            finally
            {
                _ctx.Dispose();
            }
        }
        public ApiResponseViewModel Update(Movies data)
        {
            try
            {
                if (data.id < 1)
                    return new ApiResponseViewModel() { status = false, statusCode = 400, message = "Movie id can't be less than 1" };

                Movies Data = _repo.GetList().Where(f => f.id == data.id).FirstOrDefault();
                if (Data == null)
                    return new ApiResponseViewModel() { status = false, statusCode = 400, message = "Movie id is not exist" };

                _repo.Update(data);

                return new ApiResponseViewModel() { status = true, statusCode = 200, message = "Movie has been updated" };
            }
            catch (Exception x)
            {
                return new ApiResponseViewModel() { status = false, statusCode = 400, message = x.Message };
            }
            finally
            {
                _ctx.Dispose();
            }
        }
        public ApiResponseViewModel Delete(int id)
        {
            try
            {
                if (id < 1)
                    return new ApiResponseViewModel() { status = false, statusCode = 400, message = "Movie id can't be less than 1" };

                Movies Data = _repo.GetList().Where(f => f.id == id).FirstOrDefault();
                if (Data == null)
                    return new ApiResponseViewModel() { status = false, statusCode = 400, message = "Movie id is not exist" };

                _repo.Delete(Data);

                return new ApiResponseViewModel() { status = true, statusCode = 200, message = "Movie has been removed" };
            }
            catch (Exception x)
            {
                return new ApiResponseViewModel() { status = false, statusCode = 400, message = x.Message };
            }
            finally
            {
                _ctx.Dispose();
            }
        }
    }
}
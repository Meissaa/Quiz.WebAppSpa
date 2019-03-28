using Quiz.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using Quiz.WebApi.Models.Auth;
using Quiz.Common.Exceptions;

namespace Quiz.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private static ILog _log;
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {

            if (authManager == null)
                throw new ArgumentException("authManager");

            _log = LogManager.GetLogger(this.GetType().FullName);
            _authManager = authManager;

        }

        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginRequest request)
        {

            try
            {
                _log.Debug("begin Login");

                if (request == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request is null");

                _authManager.Login(request.Username, request.Password);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (AuthException authorizationEx)
            {

                _log.Error("Login error", authorizationEx);
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, authorizationEx.Message);
            }
            catch (Exception ex)
            {

                _log.Error("Login error", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            try
            {
                _log.Debug("begin Logout");
                _authManager.Logout();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex) {

                _log.Error("Logout error", ex);
                throw ex;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using ExemploDeUsoDapper.Models;

namespace ExemploDeUsoDapper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ConnectionBD cx=new ConnectionBD();
        public ActionResult Index()
        {
            
           var dados= cx.conection.Query<User>("select * from user").ToList();
            return View(dados);
        }
        
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(User user)
        {
            cx.conection.Query("insert Into user(Id,NameUser,Email) values(@Id,@NameUser,@Email)",new {Email=user.Email,NameUser=user.NameUser,Id=user.ID});
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var user = cx.conection.Query<User>("select Id, NameUser ,Email from user where Id =@Id ", new {Id = id}).First();
            return View(user);
        }
        [HttpPost]
        public ActionResult Editar(User user)
        {
          var usuario = cx.conection.Query("update User set NameUser= @NameUser , Email= @Email where Id = @Id",new {NameUser = user.NameUser, Email = user.Email, Id = user.ID});
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            cx.conection.Query("delete from user where Id= @Id", new {Id = id});
            return RedirectToAction("Index");
        }
    }
}
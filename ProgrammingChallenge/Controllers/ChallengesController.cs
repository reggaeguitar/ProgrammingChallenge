using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace ProgrammingChallenge.Controllers
{
    public class ChallengesController : Controller
    {
        private readonly IProgrammingChallengeContextFactory _ctxFactory; // todo next make a context factory

        public ChallengesController(IProgrammingChallengeContextFactory contextFactory)
        {
            _ctxFactory = contextFactory;
        }

        // GET: Challenges
        public ActionResult Index()
        {
            using (var ctx = _ctxFactory.Create())
            {
                return View(ctx.Challenges.ToList());
            }
        }

        // GET: Challenges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var ctx = _ctxFactory.Create())
            {
                Challenge challenge = ctx.Challenges.Find(id);
                if (challenge == null)
                {
                    return HttpNotFound();
                }
                return View(challenge);
            }
        }

        // GET: Challenges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Challenges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChallengeId,Description,DueDate,Url,MiscDescription")] Challenge challenge)
        {
            using (var ctx = _ctxFactory.Create())
            {
                if (ModelState.IsValid)
                {
                    ctx.Challenges.Add(challenge);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(challenge);
            }
        }

        // GET: Challenges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var ctx = _ctxFactory.Create())
            {
                Challenge challenge = ctx.Challenges.Find(id);
                if (challenge == null)
                {
                    return HttpNotFound();
                }
                return View(challenge);
            }
        }

        // POST: Challenges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChallengeId,Description,DueDate,Url,MiscDescription")] Challenge challenge)
        {
            using (var ctx = _ctxFactory.Create())
            {
                if (ModelState.IsValid)
                {
                   ctx.Entry(challenge).State = EntityState.Modified;
                   ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(challenge);
            }
        }

        // GET: Challenges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var ctx = _ctxFactory.Create())
            {
                Challenge challenge = ctx.Challenges.Find(id);
                if (challenge == null)
                {
                    return HttpNotFound();
                }
                return View(challenge);
            }
        }

        // POST: Challenges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var ctx = _ctxFactory.Create())
            {
                Challenge challenge = ctx.Challenges.Find(id);
                ctx.Challenges.Remove(challenge);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

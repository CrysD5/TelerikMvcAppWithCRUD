using System;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcAppWithCRUD.Models;
using TelerikMvcAppWithCRUD.Data.Northwind;
using System.Data;

namespace TelerikMvcAppWithCRUD.Controllers
{
	public partial class GridController : Controller
    {
        private readonly NorthwindEntities _nwEnt = new NorthwindEntities();
        private static bool UpdateDatabase = false;
        public ActionResult Notes_Read(int nid, [DataSourceRequest] DataSourceRequest request)
        {
            var result = _nwEnt.AdvisoryNotes.Select(n => new AdvisoryNotesViewModel()
            {
                adlogin = n.adlogin,
                edate = n.edate,
                emaddr = n.emaddr,
                enotes = n.enotes,
                etitle = n.etitle,
                nid = n.nid,
                notefile = n.notefile
            });
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<AdvisoryNotesViewModel> notes)
        {
            var entities = new List<AdvisoryNote>();
            if (!ModelState.IsValid)
                return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
                {
                    nid = note.nid,
                    emaddr = note.emaddr.Trim(),
                    edate = note.edate,
                    adlogin = note.adlogin.Trim(),
                    etitle = note.etitle,
                    enotes = note.enotes,
                    notefile = note.notefile
                }));
            {
                using (var nwEnt = new NorthwindEntities())
                {
                    foreach (var note in notes)
                    {
                        var entity = new AdvisoryNote()
                        {
                            nid = note.nid,
                            emaddr = note.emaddr.Trim(),
                            edate = note.edate,
                            adlogin = note.adlogin.Trim(),
                            etitle = note.etitle,
                            enotes = note.enotes,
                            notefile = note.notefile
                        };
                        nwEnt.AdvisoryNotes.Add(entity);
                        entities.Add(entity);
                    }
                    nwEnt.SaveChanges();
                }
            }

            return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
            {
                nid = note.nid,
                emaddr = note.emaddr.Trim(),
                edate = note.edate,
                adlogin = note.adlogin.Trim(),
                etitle = note.etitle,
                enotes = note.enotes,
                notefile = note.notefile
            }));
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<AdvisoryNotesViewModel> notes)
        {
            var entities = new List<AdvisoryNote>();
            if (!ModelState.IsValid)
                return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
                {
                    nid = note.nid,
                    emaddr = note.emaddr.Trim(),
                    edate = note.edate,
                    adlogin = note.adlogin.Trim(),
                    etitle = note.etitle,
                    enotes = note.enotes,
                    notefile = note.notefile
                }));
            {
                using (var nwEnt = new NorthwindEntities())
                {
                    foreach (var note in notes)
                    {
                        var entity = new AdvisoryNote
                        {
                            nid = note.nid,
                            emaddr = note.emaddr.Trim(),
                            edate = note.edate,
                            adlogin = note.adlogin.Trim(),
                            etitle = note.etitle,
                            enotes = note.enotes,
                            notefile = note.notefile
                        };
                        entities.Add(entity);
                        nwEnt.AdvisoryNotes.Attach(entity);
                        nwEnt.Entry(entity).State = EntityState.Modified;
                    }
                    nwEnt.SaveChanges();
                }
            }

            return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
            {
                nid = note.nid,
                emaddr = note.emaddr.Trim(),
                edate = note.edate,
                adlogin = note.adlogin.Trim(),
                etitle = note.etitle,
                enotes = note.enotes,
                notefile = note.notefile
            }));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Destroy([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<AdvisoryNotesViewModel> notes)
        {
            var entities = new List<AdvisoryNote>();
            if (!ModelState.IsValid)
                return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
                {
                    nid = note.nid,
                    emaddr = note.emaddr.Trim(),
                    edate = note.edate,
                    adlogin = note.adlogin,
                    etitle = note.etitle,
                    enotes = note.enotes,
                    notefile = note.notefile
                }));
            {
                using (var nwEnt = new NorthwindEntities())
                {
                    foreach (var note in notes)
                    {
                        var entity = new AdvisoryNote
                        {
                            nid = note.nid,
                            emaddr = note.emaddr.Trim(),
                            edate = note.edate,
                            adlogin = note.adlogin.Trim(),
                            etitle = note.etitle,
                            enotes = note.enotes,
                            notefile = note.notefile
                        };
                        entities.Add(entity);
                        nwEnt.AdvisoryNotes.Attach(entity);
                        nwEnt.AdvisoryNotes.Remove(entity);
                    }

                    nwEnt.SaveChanges();
                }
            }

            return Json(entities.ToDataSourceResult(request, ModelState, note => new AdvisoryNotesViewModel
            {
                nid = note.nid,
                emaddr = note.emaddr.Trim(),
                edate = note.edate,
                adlogin = note.adlogin,
                etitle = note.etitle,
                enotes = note.enotes,
                notefile = note.notefile
            }));
        }

        public void UpdateNotes()




























        //public ActionResult Notes_Read([DataSourceRequest] DataSourceRequest request, string emaddr)
        //{
        //    if (Session["#students"] != null)
        //        emaddr = Session["#students"].ToString();

        //    using (var _nwEnt = new NorthwindEntities())
        //    {
        //        IQueryable<AdvisoryNote> notes = registrar.AdvisoryNotes.Where(x => x.emaddr == emaddr);
        //        DataSourceResult result = notes.ToDataSourceResult(request);
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}

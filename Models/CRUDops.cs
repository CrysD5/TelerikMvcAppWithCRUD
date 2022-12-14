using System;

public void UpdateFaculty(PortfolioFacultyRole results)
{
    PerformanceTracker pt = new PerformanceTracker(System.Reflection.MethodInfo.GetCurrentMethod().Name);
    try
    {
        if (results.faculty_id != null)
        {
            var target = dbEasel.PortfolioFacultyStatus.Where(x => x.id == results.portfoliofacultystatus_id).FirstOrDefault();

            if (target != null && target.faculty_id != results.faculty_id)
            {
                dbEasel.PortfolioFacultyStatus.Remove(target);
                dbEasel.SaveChanges();

                var newFaculty = new Data.Easel.PortfolioFacultyStatu();
                newFaculty.portfoliostudentstatus_id = results.portfoliostudentstatus_id;
                newFaculty.faculty_id = results.faculty_id;
                newFaculty.portfolioassignment_id = results.portfolioassignment_id;
                newFaculty.portfoliorole_id = results.portfoliorole_id;
                newFaculty.attemptid = 1;
                newFaculty.submitstatus = false;
                newFaculty.userdate = DateTime.Now;
                newFaculty.userlogin = Classes.clsCheckValues.sesuserid;

                dbEasel.PortfolioFacultyStatus.Add(newFaculty);
                dbEasel.SaveChanges();
            }

            if (target == null)
            {
                var newFaculty = new Data.Easel.PortfolioFacultyStatu();
                newFaculty.portfoliostudentstatus_id = results.portfoliostudentstatus_id;
                newFaculty.faculty_id = results.faculty_id;
                newFaculty.portfolioassignment_id = results.portfolioassignment_id;
                newFaculty.portfoliorole_id = results.portfoliorole_id;
                newFaculty.attemptid = 1;
                newFaculty.userdate = DateTime.Now;
                newFaculty.userlogin = Classes.clsCheckValues.sesuserid;

                dbEasel.PortfolioFacultyStatus.Add(newFaculty);
                dbEasel.SaveChanges();
            }
        }

        if (results.REVfaculty_id != null && results.isrepeat.Value == true && results.isrepeat != null)
        {
            var REVtarget = dbEasel.PortfolioFacultyStatus.Where(x => x.id == results.REVportfoliofacultystatus_id).FirstOrDefault();

            if (REVtarget != null && REVtarget.faculty_id != results.REVfaculty_id)
            {
                dbEasel.PortfolioFacultyStatus.Remove(REVtarget);
                dbEasel.SaveChanges();

                var REVnewFaculty = new Data.Easel.PortfolioFacultyStatu();
                REVnewFaculty.portfoliostudentstatus_id = results.portfoliostudentstatus_id;
                REVnewFaculty.faculty_id = results.REVfaculty_id;
                REVnewFaculty.portfolioassignment_id = results.portfolioassignment_id;
                REVnewFaculty.portfoliorole_id = results.portfoliorole_id;
                REVnewFaculty.attemptid = 2;
                REVnewFaculty.userdate = DateTime.Now;
                REVnewFaculty.userlogin = Classes.clsCheckValues.sesuserid;

                dbEasel.PortfolioFacultyStatus.Add(REVnewFaculty);
                dbEasel.SaveChanges();
            }

            if (REVtarget == null)
            {
                var REVnewFaculty = new Data.Easel.PortfolioFacultyStatu();
                REVnewFaculty.portfoliostudentstatus_id = results.portfoliostudentstatus_id;
                REVnewFaculty.faculty_id = results.REVfaculty_id;
                REVnewFaculty.portfolioassignment_id = results.portfolioassignment_id;
                REVnewFaculty.portfoliorole_id = results.portfoliorole_id;
                REVnewFaculty.attemptid = 2;
                REVnewFaculty.userdate = DateTime.Now;
                REVnewFaculty.userlogin = Classes.clsCheckValues.sesuserid;

                dbEasel.PortfolioFacultyStatus.Add(REVnewFaculty);
                dbEasel.SaveChanges();
            }
        }
        pt.Stop();
    }

    catch (Exception ex)
    {
        ErrorLogger.LogError(ex, Request.Url.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, Request.UserAgent);
        pt.Stop();
    }
}

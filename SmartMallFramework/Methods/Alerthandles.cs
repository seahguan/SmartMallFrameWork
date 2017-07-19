using OpenQA.Selenium;

namespace SmartMallFramework
{
    public class Alerthandles
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// To handle the alert message pop out in the scree. *** still in the mid of the testing. ***
        /// </summary>
        /// <param name="presentFlag"></param>
        /// <returns></returns>
        public bool checkAlert(bool presentFlag)
        {
            try
            {

                // Check the presence of alert
                IAlert alert = Browser.driver.SwitchTo().Alert();
                // Alert present; set the flag
                presentFlag = true;
                // if present consume the alert
                alert.Accept();

            }
            catch (NoAlertPresentException ex)
            {
                // Alert not present
                log.Info("No alert appear, ", ex);
            }

            return presentFlag;

        }
    }
}

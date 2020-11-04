using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.ServicesImplementations
{
    public class AgriCropSpecService : IAgriCropSpecsService
    {
        private readonly NLog.Logger _logger;
        public AgriCropSpecService()
        {
            _logger = new NLogDb.NLogDB().GetLogger();
        }

        public bool Delete(int id)
        {
            try
            {
                Queries.DeleteAgriCropSpec delete = new Queries.DeleteAgriCropSpec();
                return delete.Execute(id);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public AgriCropSpec GetAgriCropSpec(int id)
        {
            try
            {
                Queries.GetAgriCropSpec get = new Queries.GetAgriCropSpec();
                return get.Execute(id);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<AgriCropSpec> GetAgriCropSpecs()
        {
            try
            {
                Queries.GetAgriCropSpecs get = new Queries.GetAgriCropSpecs();
                return get.Execute();
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public bool Insert(AgriCropSpec agriCropSpecsService)
        {
            try
            {
                Queries.InsertAgriCropSpec insert = new Queries.InsertAgriCropSpec();
                return insert.Execute(agriCropSpecsService);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public bool Update(AgriCropSpec agriCropSpec)
        {
            try
            {
                Queries.UpdateAgriCropSpec update = new Queries.UpdateAgriCropSpec();
                return update.Execute(agriCropSpec);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw e;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }
    }
}

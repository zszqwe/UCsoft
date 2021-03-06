﻿


using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using NLite.Reflection;
using UCsoft.Common;
using UCsoft.Data;
using UCsoft.Entity;
using System.Linq.Dynamic;

namespace  UCsoft.Dao.Impl
{

    /// <summary>
    /// 自动生成的实现IVAppCompanyDao接口的Dao类。 2014-11-05 07:48:35 By 唐有炜
    /// </summary>
 public class VAppCompanyDaoImpl:IVAppCompanyDao
    {
	     #region 读操作


	   /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <returns>返回所有数据总数</returns>
        public int GetViewCount() 
        {
          using (UCDbContext db=new UCDbContext())
            {
             var models= db.VAppCompanies;
			 var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.Count();
            }
        }

		
             /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据总数</returns>
       public int GetViewCount(Expression<Func<VAppCompany, bool>> predicate)
        {
             using (UCDbContext db=new UCDbContext())
            {
             var models= db.VAppCompanies.Where<VAppCompany>(predicate);
			 var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.Count();
            }
        }




	    /// <summary>
        /// 获取所有的数据
	    /// </summary>
	    /// <returns>返回所有数据列表</returns>
        public List<VAppCompany> GetViewList() 
        {
          using (UCDbContext db=new UCDbContext())
            {
             var models= db.VAppCompanies;
			  var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.ToList();
            }
        }

		
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据列表</returns>
       public List<VAppCompany> GetViewList(Expression<Func<VAppCompany, bool>> predicate)
        {
             using (UCDbContext db=new UCDbContext())
            {
             var models= db.VAppCompanies.Where<VAppCompany>(predicate);
			   var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.ToList();
            }
        }

		/// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        public VAppCompany GetViewEntity(Expression<Func<VAppCompany, bool>> predicate) 
        {
            using (UCDbContext db=new UCDbContext())
            {
                var model =db.VAppCompanies.Where<VAppCompany>(predicate);
			    var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return model.SingleOrDefault();
		    }
        }

		
		
        /// <summary>
        /// 根据条件查询某些字段(LINQ 动态查询)
        /// </summary>
        /// <param name="selector">要查询的字段（格式：new(ID,Name)）</param>
        /// <param name="predicate">筛选条件（id=0）</param>
        /// <returns></returns>
        public IQueryable<Object> GetViewFields(string selector, string predicate)
        {
            using (UCDbContext db=new UCDbContext())
            {
                var model = db.VAppCompanies.Where(predicate).Select(selector);
                var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return (IQueryable<object>) model;
            }
        }


		   /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
       public   bool ExistsViewEntity(Expression<Func<VAppCompany , bool>> predicate)
	   {
            using (UCDbContext db=new UCDbContext())
            {
               bool status= db.VAppCompanies.Any(predicate);
               return status;
            }
        }

		

		
	   //查询分页
        public IPagination<VAppCompany> GetViewListByPage(int pageIndex, int pageSize, out int rowCount,
            IDictionary<string, UCsoft.Entity.UCEnums.OrderEmum> orders,
            Expression<Func<VAppCompany, bool>> predicate)
        {
            using (UCDbContext db = new UCDbContext())
            {
                 var roles = db.VAppCompanies.Where(predicate);
                rowCount = roles.Count();
                var prevCount = (pageIndex - 1)*pageSize;
                var models = roles
                    .Skip(prevCount)
                    .Take(pageSize);
                foreach (var order in orders)
                {
                    models = models.OrderBy(String.Format("{0} {1}", order.Key, order.Value));
                }
                var sqlText = models.GetProperty("SqlText");
                LogHelper.Debug("ELINQ Paging:<br/>" + sqlText.ToString());
                return models.ToPagination(pageSize, pageSize, rowCount);
            }
        }

		  //查询分页（动态LINQ）
        public IPagination<VAppCompany> GetViewListByPage(int pageIndex, int pageSize, out int rowCount,
            IDictionary<string, UCsoft.Entity.UCEnums.OrderEmum> orders,
            string predicate)
        {
            using (UCDbContext db = new UCDbContext())
            {
                 var roles = db.VAppCompanies.Where(predicate);
                rowCount = roles.Count();
                var prevCount = (pageIndex - 1)*pageSize;
                var models = roles
                    .Skip(prevCount)
                    .Take(pageSize);
                foreach (var order in orders)
                {
                    models = models.OrderBy(String.Format("{0} {1}", order.Key, order.Value));
                }
                var sqlText = models.GetProperty("SqlText");
                LogHelper.Debug("ELINQ Paging:<br/>" + sqlText.ToString());
                return models.ToPagination(pageSize, pageSize, rowCount);
            }
        }
	  

	  //以下是原生Sql方法==============================================================
	  //===========================================================================
	   /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="namedParameters">sql参数</param>
        /// <returns>集合</returns>
        public DataTable GetViewListBySql(string sql, dynamic namedParameters)
        {
          using (UCDbContext db=new UCDbContext())
            {
               return db.DbHelper.ExecuteDataTable(sql,namedParameters).ToList<VAppCompany>();
            }
          
        }
  #endregion

	   }
	   }

using ACoreX.Data;
using Newtonsoft.Json;
using System.Text;

namespace Smart.Core.DataSource
{
    public class DataSourceEngine
    {
        private readonly IData _data;

        public DataSourceEngine(IData data)
        {
            _data = data;
        }

        public dynamic GetDataSource(string Code)
        {
            //SELECT y.* FROM (
            //SELECT * FROM ( 
            //SELECT  [MNTY_ID] AS [ID], [MNTY_COD] AS [Code], [MNTY_DES] AS [Title], [MNTY_DES_SHRT] AS [ShortDescription],
            //[MNTY_FLG_ACT] AS [Enabled] FROM [BFS].[BFS_MONEY_TYPES] ) 
            //T WHERE  (  Title LIKE N'%ر%' OR ShortDescription LIKE N'%ر%' ) ) y 
            //ORDER BY ID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.Code = Code;
            var ds = _data.Query("select top 1 from ADM.DATA_SOURCES where DSRC_CODE = @Code", parameters);
            dynamic json = JsonConvert.DeserializeObject(ds.QueryParams);
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Select * from {0}", ds.Source);
            var result = _data.Query(query.ToString());
            return result;
        }

    }
}


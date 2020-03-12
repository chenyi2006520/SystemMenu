using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SystemMenuSample.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class HomeController : ControllerBase
    { 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(nameof(SystemMenu))]
        public IActionResult SystemMenu()
        {
            List<SystemMenuEntity> systemMenuEntities = new List<SystemMenuEntity>();
            using (SystemMenuDbContext dbContext = new SystemMenuDbContext())
            {
                systemMenuEntities = dbContext.SystemMenus.Where(s => s.id > 0).ToList();
            }

            SystemMenu rootNode = new SystemMenu()
            {
                Id = 0,
                Icon = "",
                Href = "",
                Title = "根目录",
            };
             
            GetTreeNodeListByNoLockedDTOArray(systemMenuEntities.ToArray(), rootNode);

            MenusInfoResultDTO menusInfoResultDTO = new MenusInfoResultDTO();
            menusInfoResultDTO.MenuInfo = rootNode.Child;
            menusInfoResultDTO.LogoInfo = new LogoInfo();
            menusInfoResultDTO.HomeInfo = new HomeInfo();

            return new  JsonResult(menusInfoResultDTO);
        }

        /// <summary>
        /// 递归处理数据
        /// </summary>
        /// <param name="systemMenuEntities"></param>
        /// <param name="rootNode"></param>
        public static void GetTreeNodeListByNoLockedDTOArray(SystemMenuEntity[] systemMenuEntities, SystemMenu rootNode)
        {
            if (systemMenuEntities == null || systemMenuEntities.Count() <= 0)
            {
                return;
            }
             
            var childreDataList = systemMenuEntities.Where(p => p.pid == rootNode.Id);
            if (childreDataList != null && childreDataList.Count() > 0)
            {
                rootNode.Child = new List<SystemMenu>();

                foreach (var item in childreDataList)
                {
                    SystemMenu treeNode = new SystemMenu()
                    {
                        Id = item.id,
                        Icon = item.icon,
                        Href = item.href,
                        Title = item.title,
                    };
                    rootNode.Child.Add(treeNode);
                }

                foreach (var item in rootNode.Child)
                {
                    GetTreeNodeListByNoLockedDTOArray(systemMenuEntities, item);
                }
            }
        }

    }



    /// <summary>
    /// 菜单结果对象
    /// </summary>
    public class MenusInfoResultDTO
    {
        /// <summary>
        /// 权限菜单树
        /// </summary>
        public List<SystemMenu> MenuInfo { get; set; }

        /// <summary>
        /// logo
        /// </summary>
        public LogoInfo LogoInfo { get; set; }

        /// <summary>
        /// Home
        /// </summary>
        public HomeInfo HomeInfo { get; set; }
    }

    public class LogoInfo
    {
        public string title { get; set; } = "一个牛逼的免费前端框架";
        public string image { get; set; } = "images/logo.png";
        public string href { get; set; } = "";
    }

    public class HomeInfo
    {
        public string title { get; set; } = "首页";
        public string href { get; set; } = "page/welcome-1.html?t=1";

    }


    /// <summary>
    /// 树结构对象
    /// </summary>
    public class SystemMenu
    {
        /// <summary>
        /// 数据ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public long PId { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 节点地址
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 新开Tab方式
        /// </summary>
        public string Target { get; set; } = "_self";

        /// <summary>
        /// 菜单图标样式
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<SystemMenu> Child { get; set; }
    }
}

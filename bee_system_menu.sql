/*
Navicat MySQL Data Transfer

Source Server         : 华为云
Source Server Version : 50729
Source Host           : 139.9.54.248:3306
Source Database       : beego_admin

Target Server Type    : MYSQL
Target Server Version : 50729
File Encoding         : 65001

Date: 2020-03-12 15:01:17
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for bee_system_menu
-- ----------------------------
DROP TABLE IF EXISTS `bee_system_menu`;
CREATE TABLE `bee_system_menu` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `pid` int(11) unsigned NOT NULL DEFAULT '0' COMMENT '父ID',
  `title` varchar(100) NOT NULL DEFAULT '' COMMENT '名称',
  `icon` varchar(100) NOT NULL DEFAULT '' COMMENT '菜单图标',
  `href` varchar(100) NOT NULL DEFAULT '' COMMENT '链接',
  `target` varchar(20) NOT NULL DEFAULT '_self' COMMENT '链接打开方式',
  `sort` int(11) DEFAULT '0' COMMENT '菜单排序',
  `status` tinyint(1) unsigned NOT NULL DEFAULT '1' COMMENT '状态(0:禁用,1:启用)',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注信息',
  `create_at` timestamp NULL DEFAULT NULL COMMENT '创建时间',
  `update_at` timestamp NULL DEFAULT NULL COMMENT '更新时间',
  `delete_at` timestamp NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`id`),
  KEY `title` (`title`),
  KEY `href` (`href`)
) ENGINE=InnoDB AUTO_INCREMENT=250 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='系统菜单表';

-- ----------------------------
-- Records of bee_system_menu
-- ----------------------------
INSERT INTO `bee_system_menu` VALUES ('227', '99999999', '后台首页', 'fa fa-home', 'index/welcome', '_self', '0', '1', null, null, '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('228', '0', '系统管理', 'fa fa-cog', '', '_self', '0', '1', '', null, '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('234', '228', '菜单管理', 'fa fa-tree', 'static/page/menu.html', '_self', '0', '1', '', null, '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('244', '228', '管理员管理', 'fa fa-user', 'static/page/table.html', '_self', '0', '1', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('245', '228', '图标列表', 'fa fa-bitbucket-square', 'static/page/icon.html', '_self', '0', '1', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('246', '228', '图标选择', 'fa fa-list', 'static/page/icon-picker.html', '_self', '0', '1', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('247', '228', '系统设置', 'fa fa-asterisk', 'static/page/setting.html', '_self', '0', '1', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00', null);
INSERT INTO `bee_system_menu` VALUES ('248', '228', '下拉选择', 'fa fa-arrow-up', 'static/page/table-select.html', '_self', '0', '1', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00', null);

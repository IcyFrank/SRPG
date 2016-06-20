﻿using System;
using Util;
using Mono.Data.Sqlite;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.start();
            p.add();
            p.updae();
            p.del();
            p.select();
            Game game = new Game("游戏");
            Console.WriteLine("欢迎来到"+game.explain.name + "\n\n请输入角色名称：");
            string roleName = Console.ReadLine();
            Console.WriteLine("创建角色：" + game.into(roleName));
            Console.ReadKey();
        }

        public void start()
        {
            //创建数据库名称为xuanyusong.db
            DbAccess db = new DbAccess("data source=xuanyusong.db");
            //创建数据库表，与字段
            db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
            //关闭对象
            db.CloseSqlConnection();
            Console.WriteLine("创建数据库");
        }

        void add()
        {

            //创建数据库名称为xuanyusong.db
            DbAccess db = new DbAccess("data source=xuanyusong.db");
            //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
            db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
            db.CloseSqlConnection();
            Console.WriteLine("插入数据");
        }
        void updae()
        {
            //创建数据库名称为xuanyusong.db
            DbAccess db = new DbAccess("data source=xuanyusong.db");
            db.UpdateInto("momo", new string[] { "name", "qq" }, new string[] { "'xuanyusong'", "'11111111'" }, "email", "'xuanyusong@gmail.com'");
            db.CloseSqlConnection();
            Console.WriteLine("更新数据");
        }
        void del()
        {
            //创建数据库名称为xuanyusong.db
            DbAccess db = new DbAccess("data source=xuanyusong.db");
            //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
            //db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
            //我在数据库中连续插入三条数据
            db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
            db.InsertInto("momo", new string[] { "'雨松MOMO'", "'289187120'", "'000@gmail.com'", "'www.xuanyusong.com'" });
            db.InsertInto("momo", new string[] { "'哇咔咔'", "'289187120'", "'111@gmail.com'", "'www.xuanyusong.com'" });
            //然后在删掉两条数据
            db.Delete("momo", new string[] { "email", "email" }, new string[] { "'xuanyusong@gmail.com'", "'000@gmail.com'" });
            db.CloseSqlConnection();
            Console.WriteLine("删除数据");
        }
        void select()
        {
            //创建数据库名称为xuanyusong.db
            DbAccess db = new DbAccess("data source=xuanyusong.db");
            //请注意 插入字符串是 已经要加上'宣雨松' 不然会报错
            //db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
            //我在数据库中连续插入三条数据
            db.InsertInto("momo", new string[] { "'宣雨松'", "'289187120'", "'xuanyusong@gmail.com'", "'www.xuanyusong.com'" });
            db.InsertInto("momo", new string[] { "'雨松MOMO'", "'289187120'", "'000@gmail.com'", "'www.xuanyusong.com'" });
            db.InsertInto("momo", new string[] { "'哇咔咔'", "'289187120'", "'111@gmail.com'", "'www.xuanyusong.com'" });
            //然后在删掉两条数据
            db.Delete("momo", new string[] { "email", "email" }, new string[] { "'xuanyusong@gmail.com'", "'000@gmail.com'" });
            //注解1
            SqliteDataReader sqReader = db.SelectWhere("momo", new string[] { "name", "email" }, new string[] { "qq" }, new string[] { "=" }, new string[] { "289187120" });

            while (sqReader.Read())
            {
                Console.WriteLine(sqReader.GetString(sqReader.GetOrdinal("name")) + sqReader.GetString(sqReader.GetOrdinal("email")));
            }
            db.CloseSqlConnection();
        }
    }
}

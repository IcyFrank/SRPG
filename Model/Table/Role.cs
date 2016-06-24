﻿using Model.Util;
using Model.Base;

namespace Model.Table
{
    /// <summary>
    /// 角色
    /// </summary>
    [DataTable("角色")]
    public class Role : Biont
    {

        private int id;

        public Role()
        {

        }
        public Role(string name, string intro, double mass, double atk, double def, double hp, double maxHp, double vp, double maxVp) : base(name, intro, mass, atk, def, hp, maxHp, vp, maxVp)
        {
            
        }

        [DataField("Id")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [DataField("种族")]
        public string Race_Id
        {
            get
            {
                return race_Id;
            }

            set
            {
                race_Id = value;
            }
        }

        private string race_Id;
    }
}

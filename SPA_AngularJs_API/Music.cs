//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPA_AngularJs_API
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Music
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Singers { get; set; }
        public int RunTime { get; set; }
        public System.DateTime ReleaseDate { get; set; }
    }
}

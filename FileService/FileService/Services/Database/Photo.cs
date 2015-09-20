using System;
using System.IO;
using SQLite.Net.Attributes;

namespace FileService
{
	[Table("PhotoRecordTable")]
	public class PhotoRecordTable
	{
		[Ignore]
		public Stream PictureStream { get; set; }

		[Ignore]
		public string PicturePath { get; set; }

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[NotNull]
		public string FileName { get; set; }

		public string Status { get; set; }
	}
}
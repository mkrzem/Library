namespace ClassicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedReferences : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BorrowedBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookQueues", "AwaitedBook_Id", "dbo.Books");
            DropIndex("dbo.BorrowedBooks", new[] { "Book_Id" });
            DropIndex("dbo.BookQueues", new[] { "AwaitedBook_Id" });
            RenameColumn(table: "dbo.BorrowedBooks", name: "Book_Id", newName: "BookId");
            RenameColumn(table: "dbo.BorrowedBooks", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.BookQueues", name: "AwaitedBook_Id", newName: "BookId");
            RenameIndex(table: "dbo.BorrowedBooks", name: "IX_User_Id", newName: "IX_UserId");
            AddColumn("dbo.BookQueues", "UserId", c => c.String());
            AlterColumn("dbo.BorrowedBooks", "BookId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookQueues", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.BorrowedBooks", "BookId");
            CreateIndex("dbo.BookQueues", "BookId");
            AddForeignKey("dbo.BorrowedBooks", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookQueues", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookQueues", "BookId", "dbo.Books");
            DropForeignKey("dbo.BorrowedBooks", "BookId", "dbo.Books");
            DropIndex("dbo.BookQueues", new[] { "BookId" });
            DropIndex("dbo.BorrowedBooks", new[] { "BookId" });
            AlterColumn("dbo.BookQueues", "BookId", c => c.Int());
            AlterColumn("dbo.BorrowedBooks", "BookId", c => c.Int());
            DropColumn("dbo.BookQueues", "UserId");
            RenameIndex(table: "dbo.BorrowedBooks", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.BookQueues", name: "BookId", newName: "AwaitedBook_Id");
            RenameColumn(table: "dbo.BorrowedBooks", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.BorrowedBooks", name: "BookId", newName: "Book_Id");
            CreateIndex("dbo.BookQueues", "AwaitedBook_Id");
            CreateIndex("dbo.BorrowedBooks", "Book_Id");
            AddForeignKey("dbo.BookQueues", "AwaitedBook_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.BorrowedBooks", "Book_Id", "dbo.Books", "Id");
        }
    }
}

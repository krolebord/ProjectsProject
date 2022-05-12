using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsProject.Migrations
{
    public partial class AddDomainModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PPLabels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPLabels_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PPProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPProjects_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelProject",
                columns: table => new
                {
                    LabelsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelProject", x => new { x.LabelsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_LabelProject_PPLabels_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "PPLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelProject_PPProjects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "PPProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PPNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPNotes_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PPNotes_PPProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PPProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PPTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPTasks_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PPTasks_PPProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PPProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabelNote",
                columns: table => new
                {
                    LabelsId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelNote", x => new { x.LabelsId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_LabelNote_PPLabels_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "PPLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelNote_PPNotes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "PPNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelToDoTask",
                columns: table => new
                {
                    LabelsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelToDoTask", x => new { x.LabelsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_LabelToDoTask_PPLabels_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "PPLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelToDoTask_PPTasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "PPTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelNote_NotesId",
                table: "LabelNote",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelProject_ProjectsId",
                table: "LabelProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelToDoTask_TasksId",
                table: "LabelToDoTask",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_PPLabels_UserId",
                table: "PPLabels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PPNotes_ProjectId",
                table: "PPNotes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PPNotes_UserId",
                table: "PPNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PPProjects_UserId",
                table: "PPProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PPTasks_ProjectId",
                table: "PPTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PPTasks_UserId",
                table: "PPTasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelNote");

            migrationBuilder.DropTable(
                name: "LabelProject");

            migrationBuilder.DropTable(
                name: "LabelToDoTask");

            migrationBuilder.DropTable(
                name: "PPNotes");

            migrationBuilder.DropTable(
                name: "PPLabels");

            migrationBuilder.DropTable(
                name: "PPTasks");

            migrationBuilder.DropTable(
                name: "PPProjects");
        }
    }
}

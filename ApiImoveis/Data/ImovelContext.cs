using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Imovel.Models;

#nullable disable

namespace Imovel.Data
{
    public partial class ImovelContext : DbContext
    {
        public ImovelContext()
        {
        }

        public ImovelContext(DbContextOptions<ImovelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ColumnsPriv> ColumnsPrivs { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Db> Dbs { get; set; }
        public virtual DbSet<DefaultRole> DefaultRoles { get; set; }
        public virtual DbSet<EngineCost> EngineCosts { get; set; }
        public virtual DbSet<Func> Funcs { get; set; }
        public virtual DbSet<GeneralLog> GeneralLogs { get; set; }
        public virtual DbSet<GlobalGrant> GlobalGrants { get; set; }
        public virtual DbSet<GtidExecuted> GtidExecuteds { get; set; }
        public virtual DbSet<HelpCategory> HelpCategories { get; set; }
        public virtual DbSet<HelpKeyword> HelpKeywords { get; set; }
        public virtual DbSet<HelpRelation> HelpRelations { get; set; }
        public virtual DbSet<HelpTopic> HelpTopics { get; set; }
        public virtual DbSet<InnodbIndexStat> InnodbIndexStats { get; set; }
        public virtual DbSet<InnodbTableStat> InnodbTableStats { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }
        public virtual DbSet<Plugin> Plugins { get; set; }
        public virtual DbSet<ProcsPriv> ProcsPrivs { get; set; }
        public virtual DbSet<ProxiesPriv> ProxiesPrivs { get; set; }
        public virtual DbSet<ReplicationAsynchronousConnectionFailover> ReplicationAsynchronousConnectionFailovers { get; set; }
        public virtual DbSet<ReplicationAsynchronousConnectionFailoverManaged> ReplicationAsynchronousConnectionFailoverManageds { get; set; }
        public virtual DbSet<ReplicationGroupConfigurationVersion> ReplicationGroupConfigurationVersions { get; set; }
        public virtual DbSet<ReplicationGroupMemberAction> ReplicationGroupMemberActions { get; set; }
        public virtual DbSet<RoleEdge> RoleEdges { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<ServerCost> ServerCosts { get; set; }
        public virtual DbSet<SlaveMasterInfo> SlaveMasterInfos { get; set; }
        public virtual DbSet<SlaveRelayLogInfo> SlaveRelayLogInfos { get; set; }
        public virtual DbSet<SlaveWorkerInfo> SlaveWorkerInfos { get; set; }
        public virtual DbSet<SlowLog> SlowLogs { get; set; }
        public virtual DbSet<TablesPriv> TablesPrivs { get; set; }
        public virtual DbSet<TimeZoneLeapSecond> TimeZoneLeapSeconds { get; set; }
        public virtual DbSet<TimeZoneName> TimeZoneNames { get; set; }
        public virtual DbSet<TimeZoneTransition> TimeZoneTransitions { get; set; }
        public virtual DbSet<TimeZoneTransitionType> TimeZoneTransitionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ImovelDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<ColumnsPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.Db, e.TableName, e.ColumnName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

                entity.ToTable("columns_priv");

                entity.HasComment("Column privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Db)
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("Table_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(64)
                    .HasColumnName("Column_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("component");

                entity.HasComment("Components")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.ComponentGroupId).HasColumnName("component_group_id");

                entity.Property(e => e.ComponentUrn)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("component_urn");
            });

            modelBuilder.Entity<Db>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.Db1 })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("db");

                entity.HasComment("Database privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.HasIndex(e => e.User, "User");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Db1)
                    .HasMaxLength(64)
                    .HasColumnName("Db")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.AlterPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Alter_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AlterRoutinePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Alter_routine_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreatePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateRoutinePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_routine_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateTmpTablePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_tmp_table_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateViewPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_view_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.DeletePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Delete_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.DropPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Drop_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.EventPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Event_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ExecutePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Execute_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.GrantPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Grant_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.IndexPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Index_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.InsertPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Insert_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.LockTablesPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Lock_tables_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ReferencesPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("References_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.SelectPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Select_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ShowViewPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Show_view_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.TriggerPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Trigger_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.UpdatePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Update_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<DefaultRole>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.DefaultRoleHost, e.DefaultRoleUser })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("default_roles");

                entity.HasComment("Default roles")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasColumnName("USER")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.DefaultRoleHost)
                    .HasColumnName("DEFAULT_ROLE_HOST")
                    .HasDefaultValueSql("'%'")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.DefaultRoleUser)
                    .HasMaxLength(32)
                    .HasColumnName("DEFAULT_ROLE_USER")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EngineCost>(entity =>
            {
                entity.HasKey(e => new { e.CostName, e.EngineName, e.DeviceType })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("engine_cost");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CostName)
                    .HasMaxLength(64)
                    .HasColumnName("cost_name");

                entity.Property(e => e.EngineName)
                    .HasMaxLength(64)
                    .HasColumnName("engine_name");

                entity.Property(e => e.DeviceType).HasColumnName("device_type");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1024)
                    .HasColumnName("comment");

                entity.Property(e => e.CostValue).HasColumnName("cost_value");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("default_value")
                    .HasComputedColumnSql("case `cost_name` when _utf8mb4\\'io_block_read_cost\\' then 1.0 when _utf8mb4\\'memory_block_read_cost\\' then 0.25 else NULL end", false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Func>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("func");

                entity.HasComment("User defined functions")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Dl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("dl")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Ret).HasColumnName("ret");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('function','aggregate')")
                    .HasColumnName("type")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<GeneralLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("general_log");

                entity.HasComment("General log")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Argument)
                    .IsRequired()
                    .HasColumnType("mediumblob")
                    .HasColumnName("argument");

                entity.Property(e => e.CommandType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("command_type");

                entity.Property(e => e.EventTime)
                    .HasColumnType("timestamp(6)")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("event_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserHost)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("user_host");
            });

            modelBuilder.Entity<GlobalGrant>(entity =>
            {
                entity.HasKey(e => new { e.User, e.Host, e.Priv })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("global_grants");

                entity.HasComment("Extended global grants")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasColumnName("USER")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Priv)
                    .HasMaxLength(32)
                    .HasColumnName("PRIV")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.WithGrantOption)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("WITH_GRANT_OPTION")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<GtidExecuted>(entity =>
            {
                entity.HasKey(e => new { e.SourceUuid, e.IntervalStart })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("gtid_executed");

                entity.Property(e => e.SourceUuid)
                    .HasColumnName("source_uuid")
                    .HasComment("uuid of the source where the transaction was originally executed.");

                entity.Property(e => e.IntervalStart)
                    .HasColumnName("interval_start")
                    .HasComment("First number of interval.");

                entity.Property(e => e.IntervalEnd)
                    .HasColumnName("interval_end")
                    .HasComment("Last number of interval.");
            });

            modelBuilder.Entity<HelpCategory>(entity =>
            {
                entity.ToTable("help_category");

                entity.HasComment("help categories")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.HelpCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("help_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<HelpKeyword>(entity =>
            {
                entity.ToTable("help_keyword");

                entity.HasComment("help keywords")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.HelpKeywordId)
                    .ValueGeneratedNever()
                    .HasColumnName("help_keyword_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<HelpRelation>(entity =>
            {
                entity.HasKey(e => new { e.HelpKeywordId, e.HelpTopicId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("help_relation");

                entity.HasComment("keyword-topic relation")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.HelpKeywordId).HasColumnName("help_keyword_id");

                entity.Property(e => e.HelpTopicId).HasColumnName("help_topic_id");
            });

            modelBuilder.Entity<HelpTopic>(entity =>
            {
                entity.ToTable("help_topic");

                entity.HasComment("help topics")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.HelpTopicId)
                    .ValueGeneratedNever()
                    .HasColumnName("help_topic_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Example)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("example");

                entity.Property(e => e.HelpCategoryId).HasColumnName("help_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<InnodbIndexStat>(entity =>
            {
                entity.HasKey(e => new { e.DatabaseName, e.TableName, e.IndexName, e.StatName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("innodb_index_stats");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.DatabaseName)
                    .HasMaxLength(64)
                    .HasColumnName("database_name");

                entity.Property(e => e.TableName)
                    .HasMaxLength(199)
                    .HasColumnName("table_name");

                entity.Property(e => e.IndexName)
                    .HasMaxLength(64)
                    .HasColumnName("index_name");

                entity.Property(e => e.StatName)
                    .HasMaxLength(64)
                    .HasColumnName("stat_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SampleSize).HasColumnName("sample_size");

                entity.Property(e => e.StatDescription)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("stat_description");

                entity.Property(e => e.StatValue).HasColumnName("stat_value");
            });

            modelBuilder.Entity<InnodbTableStat>(entity =>
            {
                entity.HasKey(e => new { e.DatabaseName, e.TableName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("innodb_table_stats");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.DatabaseName)
                    .HasMaxLength(64)
                    .HasColumnName("database_name");

                entity.Property(e => e.TableName)
                    .HasMaxLength(199)
                    .HasColumnName("table_name");

                entity.Property(e => e.ClusteredIndexSize).HasColumnName("clustered_index_size");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NRows).HasColumnName("n_rows");

                entity.Property(e => e.SumOfOtherIndexSizes).HasColumnName("sum_of_other_index_sizes");
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.PasswordTimestamp })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("password_history");

                entity.HasComment("Password history for user accounts")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordTimestamp)
                    .HasColumnType("timestamp(6)")
                    .HasColumnName("Password_timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Password).HasColumnType("text");
            });

            modelBuilder.Entity<Plugin>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("plugin");

                entity.HasComment("MySQL plugins")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Dl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("dl")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ProcsPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.Db, e.RoutineName, e.RoutineType })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

                entity.ToTable("procs_priv");

                entity.HasComment("Procedure privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.HasIndex(e => e.Grantor, "Grantor");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Db)
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(64)
                    .HasColumnName("Routine_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.RoutineType)
                    .HasColumnType("enum('FUNCTION','PROCEDURE')")
                    .HasColumnName("Routine_type");

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasMaxLength(288)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<ProxiesPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.ProxiedHost, e.ProxiedUser })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("proxies_priv");

                entity.HasComment("User proxy privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.HasIndex(e => e.Grantor, "Grantor");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.ProxiedHost)
                    .HasColumnName("Proxied_host")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.ProxiedUser)
                    .HasMaxLength(32)
                    .HasColumnName("Proxied_user")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasMaxLength(288)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.WithGrant).HasColumnName("With_grant");
            });

            modelBuilder.Entity<ReplicationAsynchronousConnectionFailover>(entity =>
            {
                entity.HasKey(e => new { e.ChannelName, e.Host, e.Port, e.NetworkNamespace, e.ManagedName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

                entity.ToTable("replication_asynchronous_connection_failover");

                entity.HasComment("The source configuration details")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => new { e.ChannelName, e.ManagedName }, "Channel_name");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(64)
                    .HasColumnName("Channel_name")
                    .IsFixedLength(true)
                    .HasComment("The replication channel name that connects source and replica.");

                entity.Property(e => e.Host)
                    .IsFixedLength(true)
                    .HasComment("The source hostname that the replica will attempt to switch over the replication connection to in case of a failure.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Port).HasComment("The source port that the replica will attempt to switch over the replication connection to in case of a failure.");

                entity.Property(e => e.NetworkNamespace)
                    .HasMaxLength(64)
                    .HasColumnName("Network_namespace")
                    .IsFixedLength(true)
                    .HasComment("The source network namespace that the replica will attempt to switch over the replication connection to in case of a failure. If its value is empty, connections use the default (global) namespace.");

                entity.Property(e => e.ManagedName)
                    .HasMaxLength(64)
                    .HasColumnName("Managed_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .HasComment("The name of the group which this server belongs to.");

                entity.Property(e => e.Weight).HasComment("The order in which the replica shall try to switch the connection over to when there are failures. Weight can be set to a number between 1 and 100, where 100 is the highest weight and 1 the lowest.");
            });

            modelBuilder.Entity<ReplicationAsynchronousConnectionFailoverManaged>(entity =>
            {
                entity.HasKey(e => new { e.ChannelName, e.ManagedName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("replication_asynchronous_connection_failover_managed");

                entity.HasComment("The managed source configuration details")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(64)
                    .HasColumnName("Channel_name")
                    .IsFixedLength(true)
                    .HasComment("The replication channel name that connects source and replica.");

                entity.Property(e => e.ManagedName)
                    .HasMaxLength(64)
                    .HasColumnName("Managed_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .HasComment("The name of the source which needs to be managed.");

                entity.Property(e => e.Configuration)
                    .HasColumnType("json")
                    .HasComment("The data to help manage group. For Managed_type = GroupReplication, Configuration value should contain {\"Primary_weight\": 80, \"Secondary_weight\": 60}, so that it assigns weight=80 to PRIMARY of the group, and weight=60 for rest of the members in mysql.replication_asynchronous_connection_failover table.");

                entity.Property(e => e.ManagedType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Managed_type")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .HasComment("Determines the managed type.");
            });

            modelBuilder.Entity<ReplicationGroupConfigurationVersion>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("replication_group_configuration_version");

                entity.HasComment("The group configuration version.");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsFixedLength(true)
                    .HasComment("The configuration name.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasComment("The version of the configuration name.");
            });

            modelBuilder.Entity<ReplicationGroupMemberAction>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.Event })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("replication_group_member_actions");

                entity.HasComment("The member actions configuration.");

                entity.HasIndex(e => e.Event, "event");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsFixedLength(true)
                    .HasComment("The action name.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Event)
                    .HasMaxLength(64)
                    .HasColumnName("event")
                    .IsFixedLength(true)
                    .HasComment("The event that will trigger the action.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasComment("Whether the action is enabled.");

                entity.Property(e => e.ErrorHandling)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("error_handling")
                    .IsFixedLength(true)
                    .HasComment("On errors during the action will be handled: IGNORE, CRITICAL.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasComment("The order on which the action will be run, value between 1 and 100, lower values first.");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("type")
                    .IsFixedLength(true)
                    .HasComment("The action type.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");
            });

            modelBuilder.Entity<RoleEdge>(entity =>
            {
                entity.HasKey(e => new { e.FromHost, e.FromUser, e.ToHost, e.ToUser })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("role_edges");

                entity.HasComment("Role hierarchy and role grants")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.FromHost)
                    .HasColumnName("FROM_HOST")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.FromUser)
                    .HasMaxLength(32)
                    .HasColumnName("FROM_USER")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.ToHost)
                    .HasColumnName("TO_HOST")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.ToUser)
                    .HasMaxLength(32)
                    .HasColumnName("TO_USER")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.WithAdminOption)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("WITH_ADMIN_OPTION")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.HasKey(e => e.ServerName)
                    .HasName("PRIMARY");

                entity.ToTable("servers");

                entity.HasComment("MySQL Foreign Servers table")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(64)
                    .HasColumnName("Server_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Db)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Socket)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Wrapper)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ServerCost>(entity =>
            {
                entity.HasKey(e => e.CostName)
                    .HasName("PRIMARY");

                entity.ToTable("server_cost");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CostName)
                    .HasMaxLength(64)
                    .HasColumnName("cost_name");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1024)
                    .HasColumnName("comment");

                entity.Property(e => e.CostValue).HasColumnName("cost_value");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("default_value")
                    .HasComputedColumnSql("case `cost_name` when _utf8mb4\\'disk_temptable_create_cost\\' then 20.0 when _utf8mb4\\'disk_temptable_row_cost\\' then 0.5 when _utf8mb4\\'key_compare_cost\\' then 0.05 when _utf8mb4\\'memory_temptable_create_cost\\' then 1.0 when _utf8mb4\\'memory_temptable_row_cost\\' then 0.1 when _utf8mb4\\'row_evaluate_cost\\' then 0.1 else NULL end", false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<SlaveMasterInfo>(entity =>
            {
                entity.HasKey(e => e.ChannelName)
                    .HasName("PRIMARY");

                entity.ToTable("slave_master_info");

                entity.HasComment("Master Information")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(64)
                    .HasColumnName("Channel_name")
                    .HasComment("The channel on which the replica is connected to a source. Used in Multisource Replication");

                entity.Property(e => e.Bind)
                    .HasColumnType("text")
                    .HasComment("Displays which interface is employed when connecting to the MySQL server")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.ConnectRetry)
                    .HasColumnName("Connect_retry")
                    .HasComment("The period (in seconds) that the slave will wait before trying to reconnect to the master.");

                entity.Property(e => e.EnabledAutoPosition)
                    .HasColumnName("Enabled_auto_position")
                    .HasComment("Indicates whether GTIDs will be used to retrieve events from the master.");

                entity.Property(e => e.EnabledSsl)
                    .HasColumnName("Enabled_ssl")
                    .HasComment("Indicates whether the server supports SSL connections.");

                entity.Property(e => e.GetPublicKey)
                    .HasColumnName("Get_public_key")
                    .HasComment("Preference to get public key from master.");

                entity.Property(e => e.GtidOnly)
                    .HasColumnName("Gtid_only")
                    .HasComment("Indicates if this channel only uses GTIDs and does not persist positions.");

                entity.Property(e => e.Host)
                    .HasMaxLength(255)
                    .HasComment("The host name of the source.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.IgnoredServerIds)
                    .HasColumnType("text")
                    .HasColumnName("Ignored_server_ids")
                    .HasComment("The number of server IDs to be ignored, followed by the actual server IDs")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.MasterCompressionAlgorithm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Master_compression_algorithm")
                    .HasComment("Compression algorithm supported for data transfer between source and replica.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.MasterLogName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Master_log_name")
                    .HasComment("The name of the master binary log currently being read from the master.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.MasterLogPos)
                    .HasColumnName("Master_log_pos")
                    .HasComment("The master log position of the last read event.");

                entity.Property(e => e.MasterZstdCompressionLevel)
                    .HasColumnName("Master_zstd_compression_level")
                    .HasComment("Compression level associated with zstd compression algorithm.");

                entity.Property(e => e.NetworkNamespace)
                    .HasColumnType("text")
                    .HasColumnName("Network_namespace")
                    .HasComment("Network namespace used for communication with the master server.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.NumberOfLines)
                    .HasColumnName("Number_of_lines")
                    .HasComment("Number of lines in the file.");

                entity.Property(e => e.Port).HasComment("The network port used to connect to the master.");

                entity.Property(e => e.PublicKeyPath)
                    .HasColumnType("text")
                    .HasColumnName("Public_key_path")
                    .HasComment("The file containing public key of master server.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.RetryCount)
                    .HasColumnName("Retry_count")
                    .HasComment("Number of reconnect attempts, to the master, before giving up.");

                entity.Property(e => e.SourceConnectionAutoFailover)
                    .HasColumnName("Source_connection_auto_failover")
                    .HasComment("Indicates whether the channel connection failover is enabled.");

                entity.Property(e => e.SslCa)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_ca")
                    .HasComment("The file used for the Certificate Authority (CA) certificate.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslCapath)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_capath")
                    .HasComment("The path to the Certificate Authority (CA) certificates.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslCert)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_cert")
                    .HasComment("The name of the SSL certificate file.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslCipher)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_cipher")
                    .HasComment("The name of the cipher in use for the SSL connection.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslCrl)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_crl")
                    .HasComment("The file used for the Certificate Revocation List (CRL)")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslCrlpath)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_crlpath")
                    .HasComment("The path used for Certificate Revocation List (CRL) files")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslKey)
                    .HasColumnType("text")
                    .HasColumnName("Ssl_key")
                    .HasComment("The name of the SSL key file.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.SslVerifyServerCert)
                    .HasColumnName("Ssl_verify_server_cert")
                    .HasComment("Whether to verify the server certificate.");

                entity.Property(e => e.TlsCiphersuites)
                    .HasColumnType("text")
                    .HasColumnName("Tls_ciphersuites")
                    .HasComment("Ciphersuites used for TLS 1.3 communication with the master server.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.TlsVersion)
                    .HasColumnType("text")
                    .HasColumnName("Tls_version")
                    .HasComment("Tls version")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.UserName)
                    .HasColumnType("text")
                    .HasColumnName("User_name")
                    .HasComment("The user name used to connect to the master.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.UserPassword)
                    .HasColumnType("text")
                    .HasColumnName("User_password")
                    .HasComment("The password used to connect to the master.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Uuid)
                    .HasColumnType("text")
                    .HasComment("The master server uuid.")
                    .UseCollation("utf8mb3_bin");
            });

            modelBuilder.Entity<SlaveRelayLogInfo>(entity =>
            {
                entity.HasKey(e => e.ChannelName)
                    .HasName("PRIMARY");

                entity.ToTable("slave_relay_log_info");

                entity.HasComment("Relay Log Information")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(64)
                    .HasColumnName("Channel_name")
                    .HasComment("The channel on which the replica is connected to a source. Used in Multisource Replication");

                entity.Property(e => e.AssignGtidsToAnonymousTransactionsType)
                    .IsRequired()
                    .HasColumnType("enum('OFF','LOCAL','UUID')")
                    .HasColumnName("Assign_gtids_to_anonymous_transactions_type")
                    .HasDefaultValueSql("'OFF'")
                    .HasComment("Indicates whether the channel will generate a new GTID for anonymous transactions. OFF means that anonymous transactions will remain anonymous. LOCAL means that anonymous transactions will be assigned a newly generated GTID based on server_uuid. UUID indicates that anonymous transactions will be assigned a newly generated GTID based on Assign_gtids_to_anonymous_transactions_value");

                entity.Property(e => e.AssignGtidsToAnonymousTransactionsValue)
                    .HasColumnType("text")
                    .HasColumnName("Assign_gtids_to_anonymous_transactions_value")
                    .HasComment("Indicates the UUID used while generating GTIDs for anonymous transactions")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Id).HasComment("Internal Id that uniquely identifies this record.");

                entity.Property(e => e.MasterLogName)
                    .HasColumnType("text")
                    .HasColumnName("Master_log_name")
                    .HasComment("The name of the master binary log file from which the events in the relay log file were read.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.MasterLogPos)
                    .HasColumnName("Master_log_pos")
                    .HasComment("The master log position of the last executed event.");

                entity.Property(e => e.NumberOfLines)
                    .HasColumnName("Number_of_lines")
                    .HasComment("Number of lines in the file or rows in the table. Used to version table definitions.");

                entity.Property(e => e.NumberOfWorkers).HasColumnName("Number_of_workers");

                entity.Property(e => e.PrivilegeChecksHostname)
                    .HasMaxLength(255)
                    .HasColumnName("Privilege_checks_hostname")
                    .HasComment("Hostname part of PRIVILEGE_CHECKS_USER.")
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.PrivilegeChecksUsername)
                    .HasMaxLength(32)
                    .HasColumnName("Privilege_checks_username")
                    .HasComment("Username part of PRIVILEGE_CHECKS_USER.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.RelayLogName)
                    .HasColumnType("text")
                    .HasColumnName("Relay_log_name")
                    .HasComment("The name of the current relay log file.")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.RelayLogPos)
                    .HasColumnName("Relay_log_pos")
                    .HasComment("The relay log position of the last executed event.");

                entity.Property(e => e.RequireRowFormat)
                    .HasColumnName("Require_row_format")
                    .HasComment("Indicates whether the channel shall only accept row based events.");

                entity.Property(e => e.RequireTablePrimaryKeyCheck)
                    .IsRequired()
                    .HasColumnType("enum('STREAM','ON','OFF')")
                    .HasColumnName("Require_table_primary_key_check")
                    .HasDefaultValueSql("'STREAM'")
                    .HasComment("Indicates what is the channel policy regarding tables having primary keys on create and alter table queries");

                entity.Property(e => e.SqlDelay)
                    .HasColumnName("Sql_delay")
                    .HasComment("The number of seconds that the slave must lag behind the master.");
            });

            modelBuilder.Entity<SlaveWorkerInfo>(entity =>
            {
                entity.HasKey(e => new { e.ChannelName, e.Id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("slave_worker_info");

                entity.HasComment("Worker Information")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(64)
                    .HasColumnName("Channel_name")
                    .HasComment("The channel on which the replica is connected to a source. Used in Multisource Replication");

                entity.Property(e => e.CheckpointGroupBitmap)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("Checkpoint_group_bitmap");

                entity.Property(e => e.CheckpointGroupSize).HasColumnName("Checkpoint_group_size");

                entity.Property(e => e.CheckpointMasterLogName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Checkpoint_master_log_name")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.CheckpointMasterLogPos).HasColumnName("Checkpoint_master_log_pos");

                entity.Property(e => e.CheckpointRelayLogName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Checkpoint_relay_log_name")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.CheckpointRelayLogPos).HasColumnName("Checkpoint_relay_log_pos");

                entity.Property(e => e.CheckpointSeqno).HasColumnName("Checkpoint_seqno");

                entity.Property(e => e.MasterLogName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Master_log_name")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.MasterLogPos).HasColumnName("Master_log_pos");

                entity.Property(e => e.RelayLogName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Relay_log_name")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.RelayLogPos).HasColumnName("Relay_log_pos");
            });

            modelBuilder.Entity<SlowLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("slow_log");

                entity.HasComment("Slow log")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Db)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("db");

                entity.Property(e => e.InsertId).HasColumnName("insert_id");

                entity.Property(e => e.LastInsertId).HasColumnName("last_insert_id");

                entity.Property(e => e.LockTime)
                    .HasMaxLength(6)
                    .HasColumnName("lock_time");

                entity.Property(e => e.QueryTime)
                    .HasMaxLength(6)
                    .HasColumnName("query_time");

                entity.Property(e => e.RowsExamined).HasColumnName("rows_examined");

                entity.Property(e => e.RowsSent).HasColumnName("rows_sent");

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.SqlText)
                    .IsRequired()
                    .HasColumnType("mediumblob")
                    .HasColumnName("sql_text");

                entity.Property(e => e.StartTime)
                    .HasColumnType("timestamp(6)")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("start_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserHost)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("user_host");
            });

            modelBuilder.Entity<TablesPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.Db, e.TableName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("tables_priv");

                entity.HasComment("Table privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.HasIndex(e => e.Grantor, "Grantor");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User)
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Db)
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("Table_name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasMaxLength(288)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<TimeZoneLeapSecond>(entity =>
            {
                entity.HasKey(e => e.TransitionTime)
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_leap_second");

                entity.HasComment("Leap seconds information for time zones")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.TransitionTime)
                    .ValueGeneratedNever()
                    .HasColumnName("Transition_time");
            });

            modelBuilder.Entity<TimeZoneName>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_name");

                entity.HasComment("Time zone names")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");
            });

            modelBuilder.Entity<TimeZoneTransition>(entity =>
            {
                entity.HasKey(e => new { e.TimeZoneId, e.TransitionTime })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("time_zone_transition");

                entity.HasComment("Time zone transitions")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");

                entity.Property(e => e.TransitionTime).HasColumnName("Transition_time");

                entity.Property(e => e.TransitionTypeId).HasColumnName("Transition_type_id");
            });

            modelBuilder.Entity<TimeZoneTransitionType>(entity =>
            {
                entity.HasKey(e => new { e.TimeZoneId, e.TransitionTypeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("time_zone_transition_type");

                entity.HasComment("Time zone transition types")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");

                entity.Property(e => e.TransitionTypeId).HasColumnName("Transition_type_id");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDst).HasColumnName("Is_DST");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User1 })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user");

                entity.HasComment("Users and global privileges")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_bin");

                entity.Property(e => e.Host)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true)
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.User1)
                    .HasMaxLength(32)
                    .HasColumnName("User")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.AccountLocked)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("account_locked")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AlterPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Alter_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AlterRoutinePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Alter_routine_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AuthenticationString)
                    .HasColumnType("text")
                    .HasColumnName("authentication_string");

                entity.Property(e => e.CreatePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateRolePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_role_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateRoutinePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_routine_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateTablespacePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_tablespace_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateTmpTablePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_tmp_table_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateUserPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_user_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CreateViewPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Create_view_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.DeletePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Delete_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.DropPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Drop_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.DropRolePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Drop_role_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.EventPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Event_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ExecutePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Execute_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.FilePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("File_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.GrantPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Grant_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.IndexPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Index_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.InsertPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Insert_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.LockTablesPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Lock_tables_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.MaxConnections).HasColumnName("max_connections");

                entity.Property(e => e.MaxQuestions).HasColumnName("max_questions");

                entity.Property(e => e.MaxUpdates).HasColumnName("max_updates");

                entity.Property(e => e.MaxUserConnections).HasColumnName("max_user_connections");

                entity.Property(e => e.PasswordExpired)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("password_expired")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.PasswordLastChanged)
                    .HasColumnType("timestamp")
                    .HasColumnName("password_last_changed");

                entity.Property(e => e.PasswordLifetime).HasColumnName("password_lifetime");

                entity.Property(e => e.PasswordRequireCurrent)
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Password_require_current")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.PasswordReuseHistory).HasColumnName("Password_reuse_history");

                entity.Property(e => e.PasswordReuseTime).HasColumnName("Password_reuse_time");

                entity.Property(e => e.Plugin)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plugin")
                    .HasDefaultValueSql("'caching_sha2_password'")
                    .IsFixedLength(true);

                entity.Property(e => e.ProcessPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Process_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ReferencesPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("References_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ReloadPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Reload_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ReplClientPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Repl_client_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ReplSlavePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Repl_slave_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.SelectPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Select_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ShowDbPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Show_db_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ShowViewPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Show_view_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ShutdownPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Shutdown_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.SslCipher)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("ssl_cipher");

                entity.Property(e => e.SslType)
                    .IsRequired()
                    .HasColumnType("enum('','ANY','X509','SPECIFIED')")
                    .HasColumnName("ssl_type")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.SuperPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Super_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.TriggerPriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Trigger_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.UpdatePriv)
                    .IsRequired()
                    .HasColumnType("enum('N','Y')")
                    .HasColumnName("Update_priv")
                    .HasDefaultValueSql("'N'")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.UserAttributes)
                    .HasColumnType("json")
                    .HasColumnName("User_attributes");

                entity.Property(e => e.X509Issuer)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("x509_issuer");

                entity.Property(e => e.X509Subject)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("x509_subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

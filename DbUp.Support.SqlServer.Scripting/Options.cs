﻿using Microsoft.SqlServer.Management.Smo;

namespace DbUp.Support.SqlServer.Scripting
{
    public class Options
    {
        public Options()
        {
            //relative to execution path; by default, place definitions in project directory which
            //is two directories up from runtime (i.e. if execution path is bin\Debug, then project directory is ..\..\
            this.BaseFolderNameDefinitions = "..\\..\\Definitions";
            this.FolderNameTables = "Tables";
            this.FolderNameViews = "Views";
            this.FolderNameProcedures = "Procedures";
            this.FolderNameFunctions = "Functions";
            this.FolderNameUserDefinedTypes = "UserDefinedTypes";
            this.FolderNameSynonyms = "Synonyms";

            this.ObjectsToInclude = ObjectTypeEnum.Function
                | ObjectTypeEnum.Procedure
                | ObjectTypeEnum.Synonym
                | ObjectTypeEnum.Table
                | ObjectTypeEnum.View
                | ObjectTypeEnum.Type;

            this.ScriptingOptions = new ScriptingOptions()
          {
              Default = true,
              ClusteredIndexes = true,
              NonClusteredIndexes = true,
              DriAll = true,
              Triggers = true
          };
        }

        public ScriptingOptions ScriptingOptions { get; set; }
        public string BaseFolderNameDefinitions { get; set; }
        public string FolderNameTables { get; set; }
        public string FolderNameViews { get; set; }
        public string FolderNameUserDefinedTypes { get; set; }
        public string FolderNameProcedures { get; set; }
        public string FolderNameFunctions { get; set; }
        public string FolderNameSynonyms { get; set; }
        public bool ScriptBatchTerminator { get; set; }
        public ObjectTypeEnum ObjectsToInclude { get; set; }
    }
}

﻿//HintName: Model_Intro_Declarations.gen.cs
// Generated from Intro_Declarations.graphql+
/*
output _Schema {
    : _Named
        categories(_CategoryFilter?): _Categories[_Identifier]
        directives(_Filter?): _Directives[_Identifier]
        types(_TypeFilter?): _Type[_Identifier]
        settings(_Filter?): _Setting[_Identifier]
    }
domain _Identifier { String /[A-Za-z_]+/ }
input _Filter  {
        names: _NameFilter[]
        matchAliases: Boolean? = true
        aliases: _NameFilter[]
        returnByAlias: Boolean? = false
        returnReferencedTypes: Boolean? = false
    | _NameFilter[]
    }
"_NameFilter is a simple match expression against _Identifier  where '.' matches any single character and '*' matches zero or more of any character."
domain _NameFilter { String /[A-Za-z_.*]+/ }
input _CategoryFilter {
    : _Filter
        resolutions: _Resolution[]
    }
input _TypeFilter {
    : _Filter
        kinds: _TypeKind[]
    }
*/
namespace GqlPlus;
public class Model_Intro_Declarations {}
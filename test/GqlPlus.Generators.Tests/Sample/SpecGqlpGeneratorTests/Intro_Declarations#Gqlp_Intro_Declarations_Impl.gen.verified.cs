//HintName: Gqlp_Intro_Declarations_Impl.gen.cs
// Generated from Intro_Declarations.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Declarations;

public class Output_Schema
  : Output_Named
  , I_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public class Domain_Identifier
  : I_Identifier
{
}

public class Input_Filter
  : I_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public class Domain_NameFilter
  : I_NameFilter
{
}

public class Input_CategoryFilter
  : Input_Filter
  , I_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public class Input_TypeFilter
  : Input_Filter
  , I_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

//HintName: Gqlp_Intro_Names_Impl.gen.cs
// Generated from Intro_Names.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Names;

public class Dual_Aliased
  : Dual_Named
  , I_Aliased
{
  public _Identifier aliases { get; set; }
}

public class Dual_Named
  : Dual_Described
  , I_Named
{
  public _Identifier name { get; set; }
}

public class Dual_Described
  : I_Described
{
  public String description { get; set; }
}

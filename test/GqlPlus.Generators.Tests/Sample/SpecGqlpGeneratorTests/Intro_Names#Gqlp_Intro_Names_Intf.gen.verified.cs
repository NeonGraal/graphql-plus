//HintName: Gqlp_Intro_Names_Intf.gen.cs
// Generated from Intro_Names.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Names;

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}

public interface I_Described
{
  String description { get; }
}

public interface I_AndType
  : I_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}

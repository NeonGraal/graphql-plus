//HintName: Model_Intro_Names.gen.cs
// Generated from Intro_Names.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro_Names;

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}
public class Dual_Aliased
  : Dual_Named
  , I_Aliased
{
  public _Identifier aliases { get; set; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}
public class Dual_Named
  : Dual_Described
  , I_Named
{
  public _Identifier name { get; set; }
}

public interface I_Described
{
  String description { get; }
}
public class Dual_Described
  : I_Described
{
  public String description { get; set; }
}

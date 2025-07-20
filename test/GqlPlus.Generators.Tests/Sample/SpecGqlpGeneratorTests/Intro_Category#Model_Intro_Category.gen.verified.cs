//HintName: Model_Intro_Category.gen.cs
// Generated from Intro_Category.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro_Category;

public interface I_Categories
{
  _Category category { get; }
  _Type type { get; }
  _Category As_Category { get; }
  _Type As_Type { get; }
}
public class Output_Categories
  : I_Categories
{
  public _Category category { get; set; }
  public _Type type { get; set; }
  public _Category As_Category { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Category
  : I_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> name { get; }
  _Modifiers modifiers { get; }
}
public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> name { get; set; }
  public _Modifiers modifiers { get; set; }
}

public enum _Resolution
{
  Parallel,
  Sequential,
  Single,
}

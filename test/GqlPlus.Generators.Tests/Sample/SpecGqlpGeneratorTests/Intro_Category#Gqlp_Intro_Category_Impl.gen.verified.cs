//HintName: Gqlp_Intro_Category_Impl.gen.cs
// Generated from Intro_Category.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Category;
public class Output_Categories
  : I_Categories
{
  public _Category category { get; set; }
  public _Type type { get; set; }
  public _Category As_Category { get; set; }
  public _Type As_Type { get; set; }
}
public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> name { get; set; }
  public _Modifiers modifiers { get; set; }
}

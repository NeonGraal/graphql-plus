//HintName: Model_Intro_Directive.gen.cs
// Generated from Intro_Directive.graphql+

/*
*/

namespace GqlTest.Model_Intro_Directive;

public interface I_Directives
{
  _Directive directive { get; }
  _Type type { get; }
  _Directive As_Directive { get; }
  _Type As_Type { get; }
}
public class Output_Directives
{
  public _Directive directive { get; set; }
  public _Type type { get; set; }
  public _Directive As_Directive { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Directive
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}
public class Output_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public enum _Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

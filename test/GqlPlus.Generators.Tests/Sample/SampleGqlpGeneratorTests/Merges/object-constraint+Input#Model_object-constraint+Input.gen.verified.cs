//HintName: Model_object-constraint+Input.gen.cs
// Generated from object-constraint+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_constraint_Input;

public interface IObjCnstInp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class InputObjCnstInp<Ttype>
  : IObjCnstInp<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}

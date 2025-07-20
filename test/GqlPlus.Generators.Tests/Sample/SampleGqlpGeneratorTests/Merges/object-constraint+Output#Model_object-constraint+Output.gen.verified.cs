//HintName: Model_object-constraint+Output.gen.cs
// Generated from object-constraint+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_constraint_Output;

public interface IObjCnstOutp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class OutputObjCnstOutp<Ttype>
  : IObjCnstOutp<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}

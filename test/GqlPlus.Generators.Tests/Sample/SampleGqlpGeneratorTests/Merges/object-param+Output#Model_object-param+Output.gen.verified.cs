//HintName: Model_object-param+Output.gen.cs
// Generated from object-param+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_Output;

public interface IObjParamOutp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class OutputObjParamOutp<Ttest,Ttype>
  : IObjParamOutp<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

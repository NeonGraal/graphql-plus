//HintName: Model_object-param+Input.gen.cs
// Generated from object-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_Input;

public interface IObjParamInp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class InputObjParamInp<Ttest,Ttype>
  : IObjParamInp<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

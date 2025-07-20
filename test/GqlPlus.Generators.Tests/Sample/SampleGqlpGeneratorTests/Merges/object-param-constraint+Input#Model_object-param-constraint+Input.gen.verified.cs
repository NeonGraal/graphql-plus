//HintName: Model_object-param-constraint+Input.gen.cs
// Generated from object-param-constraint+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_constraint_Input;

public interface IObjParamCnstInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class InputObjParamCnstInp<Ttest>
  : IObjParamCnstInp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

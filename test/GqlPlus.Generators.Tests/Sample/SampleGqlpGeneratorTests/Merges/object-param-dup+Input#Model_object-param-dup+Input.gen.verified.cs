//HintName: Model_object-param-dup+Input.gen.cs
// Generated from object-param-dup+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_dup_Input;

public interface IObjParamDupInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class InputObjParamDupInp<Ttest>
  : IObjParamDupInp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

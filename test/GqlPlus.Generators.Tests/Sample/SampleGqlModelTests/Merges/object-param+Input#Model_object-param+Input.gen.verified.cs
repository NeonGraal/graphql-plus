//HintName: Model_object-param+Input.gen.cs
// Generated from object-param+Input.graphql+

/*
*/

namespace GqlTest.Model_object_param_Input;

public interface IInpObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class InputInpObjParam<Ttest,Ttype>
  : IInpObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

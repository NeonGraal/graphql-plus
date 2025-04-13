//HintName: Model_object-param+input.gen.cs
// Generated from object-param+input.graphql+

/*
*/

namespace GqlTest.Model_object_param_input;

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

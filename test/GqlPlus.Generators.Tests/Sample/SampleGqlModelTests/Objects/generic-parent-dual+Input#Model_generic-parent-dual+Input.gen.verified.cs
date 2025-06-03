//HintName: Model_generic-parent-dual+Input.gen.cs
// Generated from generic-parent-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Input;

public interface IGnrcPrntDualInp
  : IRefGnrcPrntDualInp
{
}
public class InputGnrcPrntDualInp
  : InputRefGnrcPrntDualInp
  , IGnrcPrntDualInp
{
}

public interface IRefGnrcPrntDualInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcPrntDualInp<Tref>
  : IRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntDualInp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualInp
  : IAltGnrcPrntDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

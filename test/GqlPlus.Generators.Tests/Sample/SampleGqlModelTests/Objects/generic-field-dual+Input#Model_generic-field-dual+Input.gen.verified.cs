//HintName: Model_generic-field-dual+Input.gen.cs
// Generated from generic-field-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_Input;

public interface IGnrcFieldDualInp
{
  RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; }
}
public class InputGnrcFieldDualInp
  : IGnrcFieldDualInp
{
  public RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; set; }
}

public interface IRefGnrcFieldDualInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcFieldDualInp<Tref>
  : IRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldDualInp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcFieldDualInp
  : IAltGnrcFieldDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

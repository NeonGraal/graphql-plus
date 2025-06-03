//HintName: Model_generic-field-dual+Output.gen.cs
// Generated from generic-field-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_Output;

public interface IGnrcFieldDualOutp
{
  RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; }
}
public class OutputGnrcFieldDualOutp
  : IGnrcFieldDualOutp
{
  public RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; set; }
}

public interface IRefGnrcFieldDualOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcFieldDualOutp<Tref>
  : IRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcFieldDualOutp
  : IAltGnrcFieldDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

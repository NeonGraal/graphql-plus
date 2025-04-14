//HintName: Model_generic-field-dual+output.gen.cs
// Generated from generic-field-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_output;

public interface IOutpGnrcFieldDual
{
  RefOutpGnrcFieldDual<AltOutpGnrcFieldDual> field { get; }
}
public class OutputOutpGnrcFieldDual
  : IOutpGnrcFieldDual
{
  public RefOutpGnrcFieldDual<AltOutpGnrcFieldDual> field { get; set; }
}

public interface IRefOutpGnrcFieldDual<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcFieldDual<Tref>
  : IRefOutpGnrcFieldDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcFieldDual
  : IAltOutpGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

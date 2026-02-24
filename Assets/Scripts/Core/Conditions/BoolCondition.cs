public class BoolCondition : BaseCondition
{
    private readonly bool _expected;
    private readonly Tag<bool> _tag;

    public BoolCondition(string id, Tag<bool> tag, bool expected) : base(id)
    {
        _tag = tag;
        _expected = expected;
    }

    protected override bool CheckCondition()
    {
        return _tag.Value == _expected;
    }
}

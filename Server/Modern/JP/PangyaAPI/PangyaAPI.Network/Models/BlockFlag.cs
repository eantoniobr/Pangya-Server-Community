namespace PangyaAPI.Network.Models;

public class BlockFlag
{
	public IDStateBlockFlag m_id_state;

	public Flag m_flag;

	public BlockFlag()
	{
		if (m_flag == null || m_flag.ullFlag == 0L)
		{
			m_flag = new Flag(0uL);
		}
		m_id_state = new IDStateBlockFlag(0uL);
	}

	public void setIDState(ulong _id_state)
	{
		m_id_state = new IDStateBlockFlag(_id_state);
		if (m_id_state.L_BLOCK_LOUNGE)
		{
			m_flag.lounge = true;
		}
		if (m_id_state.L_BLOCK_SHOP_LOUNGE)
		{
			m_flag.personal_shop = true;
		}
		if (m_id_state.L_BLOCK_GIFT_SHOP)
		{
			m_flag.gift_shop = true;
		}
		if (m_id_state.L_BLOCK_PAPEL_SHOP)
		{
			m_flag.papel_shop = true;
		}
		if (m_id_state.L_BLOCK_SCRATCHY)
		{
			m_flag.scratchy = true;
		}
		if (m_id_state.L_BLOCK_TICKER)
		{
			m_flag.ticker = true;
		}
		if (m_id_state.L_BLOCK_MEMORIAL_SHOP)
		{
			m_flag.memorial_shop = true;
		}
	}
}

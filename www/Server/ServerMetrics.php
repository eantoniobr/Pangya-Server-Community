<?php

final class ServerMetrics
{
    public function __construct(private PDO $pdo)
    {
    }

    public function snapshot(): array
    {
        $result = [
            'registered' => 0,
            'online' => 0,
            'login_online' => false,
            'game_online' => false,
            'pang_rate' => 0,
            'exp_rate' => 0,
            'peak_online' => 0,
        ];

        try {
            $result['registered'] = (int) $this->pdo->query('SELECT COUNT(*) FROM pangya.account')->fetchColumn();
            $result['online'] = (int) $this->pdo->query('SELECT COUNT(*) FROM pangya.account WHERE [Logon] = 1')->fetchColumn();
            $result['peak_online'] = $result['online'];

            $server = $this->pdo->query(
                'SELECT 
            CONVERT(
                VARCHAR(MAX),
                CAST(pangya_server_list.[Name] AS VARBINARY(MAX)),
                2
            ) AS [Name_HEX],

            pangya_server_list.[UID], 
            pangya_server_list.[IP], 
            pangya_server_list.[Port], 
            pangya_server_list.MaxUser, 
            pangya_server_list.CurrUser, 
            pangya_server_list.property, 
            pangya_server_list.AngelicWingsNum, 
            pangya_server_list.EventFlag, 
            pangya_server_list.EventMap, 
            pangya_server_list.ImgNo, 
            pangya_server_list.AppRate, 
            pangya_server_list.ScratchRate

        FROM pangya.pangya_server_list

        WHERE 
            pangya_server_list.[Type] = 1 AND 
            pangya_server_list.UpdateTime > dateadd(second, -8, getdate()) AND 
            pangya_server_list.[State] = 1'
            )->fetch();

            if ($server) {
                $result['game_online'] = 1;
                $result['login_online'] = $result['game_online'];
                $result['online'] = max($result['online'], (int) $server['CurrUser']);
                $result['peak_online'] = max($result['peak_online'], (int) $server['CurrUser']);
                $result['exp_rate'] = (float) $server['AppRate'];
                $result['pang_rate'] = (float) $server['ScratchRate'];
            }
        } catch (PDOException $exception) {
            error_log('Não foi possível obter métricas do servidor: ' . $exception->getMessage());
        }

        return $result;
    }
}
